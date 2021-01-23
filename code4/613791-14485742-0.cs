    private static string CreateExecuteMethodTemplate(string content)
    {
        var builder = new StringBuilder();
        builder.Append("using System;");
        builder.Append("\r\nnamespace Lab");
        builder.Append("\r\n{");
        builder.Append("\r\npublic sealed class Cal");
        builder.Append("\r\n{");
        builder.Append("\r\npublic static object Execute()");
        builder.Append("\r\n{");
        builder.AppendFormat("\r\nreturn {0};", content);
        builder.Append("\r\n}");
        builder.Append("\r\n}");
        builder.Append("\r\n}");
        return builder.ToString();
    }
    private static object Execute(string content)
    {
        var codeProvider = new CSharpCodeProvider();
        var compilerParameters = new CompilerParameters
        {
            GenerateExecutable = false,
            GenerateInMemory = true
        };
        compilerParameters.ReferencedAssemblies.Add("system.dll");
        string sourceCode = CreateExecuteMethodTemplate(content);
        CompilerResults compilerResults = codeProvider.CompileAssemblyFromSource(compilerParameters, sourceCode);
        Assembly assembly = compilerResults.CompiledAssembly;
        Type type = assembly.GetType("Lab.Cal");
        MethodInfo methodInfo = type.GetMethod("Execute");
        return methodInfo.Invoke(null, null);
    }
