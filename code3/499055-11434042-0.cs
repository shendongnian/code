        public static string ParseString(string input)
        {
            var provider = new Microsoft.CSharp.CSharpCodeProvider();
            var parameters = new System.CodeDom.Compiler.CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
            };
            var code = @"
            public class TmpClass
            {
                public static string GetValue()
                {
                    return """ + input + @""";
                }
            }";
            var compileResult = provider.CompileAssemblyFromSource(parameters, code);
            if (compileResult.Errors.HasErrors)
            {
                throw new ArgumentException(compileResult.Errors.Cast<System.CodeDom.Compiler.CompilerError>().First(e => !e.IsWarning).ErrorText);
            }
            var asmb = compileResult.CompiledAssembly;
            var method = asmb.GetType("TmpClass").GetMethod("GetValue");
            return method.Invoke(null, null) as string;
        }
