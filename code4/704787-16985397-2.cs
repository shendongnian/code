    public Type GetType(string friendlyName)
    {
        var provider = new CSharpCodeProvider();
		
        var pars = new CompilerParameters
		{
        	GenerateExecutable = false,
        	GenerateInMemory = true
		};
		string code = "public class TypeFullNameGetter"
		            + "{"
					+ "		public override string ToString()"
					+ "		{"
					+ "			return typeof(" + friendlyName + ").FullName;"
					+ "		}"
					+ "}";
						  
        var comp = provider.CompileAssemblyFromSource(pars, new[] { code });
        if (comp.Errors.Count > 0)
			return null;
		
		object fullNameGetter = comp.CompiledAssembly.CreateInstance("TypeFullNameGetter");
        string fullName = fullNameGetter.ToString();			
		return Type.GetType(fullName);
    }
