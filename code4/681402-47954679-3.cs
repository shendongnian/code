    /// <summary>
    ///   CompileEntity
    /// </summary>
    /// <param name="name"></param>
    /// <param name="subTypeRef"></param>
    /// <param name="accessor"></param>
    /// <returns>The newly created type of the object.</returns>
    private static Type CompileEntity(string name, Type subTypeRef, string accessor) {
      var sb = new StringBuilder();
      sb.Append(@"
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;
        
    namespace HearthMirror.TypeBuilder {
      [CompilerGenerated]     // <======= !!!!! HERE !!!!!!
      public class ").Append(name).AppendLine(@" {");
        
        if (subTypeRef != null) {
    	  // Reference to subType class.
          sb.AppendLine($"	public {subTypeRef.Name} {accessor}").AppendLine(" { get; set; }");
        }
        
        sb.Append("  }\n}");
       
        var asm = RuntimeCodeCompiler.CompileCode(sb.ToString());
        var type = asm.GetType($"{MethodBase.GetCurrentMethod().ReflectedType?.Namespace}.{tok}"); // => generated
    
      // Register our type for reference.   This container will handle collisions and throw if encountered.
      obj.RefTypes.Add(tok, type);
      if (type.GetCustomAttribute(typeof(CompilerGeneratedAttribute), true) != null)
        return type;
      return null;
     }
    
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
