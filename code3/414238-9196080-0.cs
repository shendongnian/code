	void Main()
	{
		dynamic instanceOfMyType;
		
		using (CSharpCodeProvider csharpCodeProvider = new CSharpCodeProvider())
		{
		
			var outPutFile = Path.ChangeExtension(Path.GetTempFileName(), ".dll");
			CompilerParameters parameters = new CompilerParameters()
			{
				//For creating DLLs it should be false
				GenerateExecutable = false,
				OutputAssembly = outPutFile,
				//For displaying warnings in the compilerResults
				WarningLevel = 4,
				
			};
			//I am reading the text from a WPF RichTextbox
			var text = File.ReadAllText(@"c:\temp\SampleFoo.cs");
			CompilerResults compilerResults = csharpCodeProvider.CompileAssemblyFromSource(parameters, text);
				
			var type = compilerResults.CompiledAssembly.GetType("SampleFoo");
			instanceOfMyType = Activator.CreateInstance(type);
		}
		Console.WriteLine (instanceOfMyType.Bar);
	}
