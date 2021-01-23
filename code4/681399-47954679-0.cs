    	/// <summary>
    	///   CompileEntity
    	/// </summary>
    	/// <param name="name"></param>
    	/// <param name="subTypeRef"></param>
    	/// <param name="accessor"></param>
    	/// <returns>The newly created type of the object.</returns>
    	private static Type CompileEntity(string name, Type subTypeRef, string accessor) {
    	  var sb = new StringBuilder();
          sb.Append(@"using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace HearthMirror.TypeBuilder {
      public class ").Append(name).AppendLine(@" {");
    
          if (subTypeRef != null) {
    		// Reference to subType class.
            sb.AppendLine($"	public {subTypeRef.Name} {accessor}").AppendLine(" { get; set; }");
          }
    
          sb.Append("  }\n}");
    
          var parameters = new CompilerParameters {
            GenerateExecutable = false,
            GenerateInMemory = true,
            IncludeDebugInformation = true
          };
          parameters.ReferencedAssemblies.Add("System.dll");
          parameters.ReferencedAssemblies.Add(typeof(Enumerable).Assembly.Location);
          parameters.ReferencedAssemblies.Add(Assembly.GetCallingAssembly().Location);
          parameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
    
          var results = new CSharpCodeProvider().CompileAssemblyFromSource(parameters, sb.ToString());
          // CompiledAssembly - Calls the Load method to load the compiled assembly into the current application domain via the 'get' accessor.
    	  if (results.Errors.Count == 0)
    		return results.CompiledAssembly.GetType($"{MethodBase.GetCurrentMethod().ReflectedType?.Namespace}.{name}"); // => generated
    	  //return (T) generated.GetConstructor(Type.EmptyTypes).Invoke(null);
    
          if (!(results.Errors.GetMemberValue("InnerList") is ArrayList list))
            throw new NullReferenceException("Unable to retrieve member object in CompilerErrorCollection.");
    
          sb.Clear();
    
          foreach (CompilerError x in list.ToArray(typeof(CompilerError))) {
            var status = x.IsWarning ? "warning" : "error";
            sb.AppendLine($"#{x.ErrorNumber}:{status}:line {x.Line}:{x.FileName} {x.ErrorText}");
          }
          throw new Exception("Compiler errors detected in HearthMirror.TypeBuilder", new Exception(sb.ToString()));
        }
