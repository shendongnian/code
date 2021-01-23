	CSharpCodeProvider codeProvider = new CSharpCodeProvider();
	ICodeCompiler icc = codeProvider.CreateCompiler();
	CompilerParameters parameters = new CompilerParameters();
	parameters.ReferencedAssemblies.Add("mydll.dll");
	parameters.GenerateExecutable = false;
	CompilerResults results = 
		icc.CompileAssemblyFromSource(parameters, 
			String.Format(@"using System;
	namespace Testing
	{{
		class Program
		{{
			static void Main(string[] args)
			{{
				{0}
				Console.ReadLine();
			}}
		}}
	}}
	", "Foo.Bar<Integer>("no good");"));
	Assert.AreNotEqual(0, results.Errors.Count);
