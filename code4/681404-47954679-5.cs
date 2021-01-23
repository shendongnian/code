        /// <summary>
        ///   CreateType
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        /// <param name="accessor"></param>
        /// <param name="hasSubTypes"></param>
        /// <returns>The newly created type of the object.</returns>
        internal static Type CreateType(this Mirror obj, string name, IEnumerable<string> properties, string accessor = "", bool hasSubTypes = false) {
          Type subTypeRef = null;
    
          // Tested Regex @ http://regex101.com
          const string subTypes = @"(?:<|(?:\$))([a-zA-Z_]+[0-9`]*)(?:>([a-zA-Z_]+[0-9`]*))";
          var match = Regex.Match(name, subTypes);
    
          if (match.Success) {
            var refType = match.Groups[1].Value; // Class reference type.
            if (match.Groups[2].Success && !string.IsNullOrEmpty(match.Groups[2].Value))
              accessor = match.Groups[2].Value; // Class accessor.
    
            // ReSharper disable once TailRecursiveCall
            var enumerable = properties as IList<string> ?? properties.ToList();
            subTypeRef = CreateType(obj, refType, enumerable, accessor, true);
    
            // Tokenize this for the actual derived class name.
            name = name.Substring(0, name.IndexOf('+'));
          }
    
          // Check if formating of the class name matches traditional valid syntax.
          // Assume at least 3 levels deep.
          var toks = name.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
          Type type = null;
    
          foreach (var tok in toks.Reverse()) {
            var o = obj.RefTypes.FirstOrDefault(t => t.Value.Name == tok);
            if (!o.Equals(default(KeyValuePair<string, Type>)))
              continue;
    
            // Not exists.
            var sb = new StringBuilder();
            sb.Append(@"
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace HearthMirror.TypeBuilder {
      [CompilerGenerated]
      public class ").Append(tok).AppendLine(@" {");
    
            if (subTypeRef != null)
              sb.AppendLine($"	public {subTypeRef.Name} {accessor}").AppendLine(" { get; set; }");
    
            sb.Append("  }\n}");
    
            var asm = RuntimeCodeCompiler.CompileCode(sb.ToString());
            type = asm.GetType($"{MethodBase.GetCurrentMethod().ReflectedType?.Namespace}.{tok}"); // => generated
    
            // Register our type for reference.   This container will handle collisions and throw if encountered.
            obj.RefTypes.Add(tok, type);
          }
    
          return type;
        }
    
> 
    /// <summary>
    ///  CompileCode
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static Assembly CompileCode(string code) {
      var provider = new CSharpCodeProvider();
      var compilerparams = new CompilerParameters { GenerateExecutable = false, GenerateInMemory = true, IncludeDebugInformation = true };
    
      foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
    	try {
    	  var location = assembly.Location;
    	  if (!string.IsNullOrEmpty(location))
    		compilerparams.ReferencedAssemblies.Add(location);
    	} catch (NotSupportedException) {
    	  // this happens for dynamic assemblies, so just ignore it. 
    	}
      }
    
      var results = provider.CompileAssemblyFromSource(compilerparams, code);
      if (results.Errors.HasErrors) {
    	var errors = new StringBuilder("Compiler Errors :\r\n");
    	foreach (CompilerError error in results.Errors)
    	  errors.AppendFormat("Line {0},{1}\t: {2}\n", error.Line, error.Column, error.ErrorText);
    	throw new Exception(errors.ToString());
      }
      AppDomain.CurrentDomain.Load(results.CompiledAssembly.GetName());
      return results.CompiledAssembly;
    }
