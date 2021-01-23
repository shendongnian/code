            var outputFile = "Greeter.dll";
            var syntaxTree = SyntaxTree.ParseCompilationUnit(@"
     // ADDED THE FOLLOWING LINE
    using System;
    class Greeter
    {
        public void Greet()
        {
            Console.WriteLine(""Hello, World"");
        }
    }");
            var compilation = Compilation.Create(outputFile,
                syntaxTrees: new[] { syntaxTree },
                references: new[] {
                    new AssemblyFileReference(typeof(object).Assembly.Location),
                    new AssemblyFileReference(typeof(Enumerable).Assembly.Location),
                },
    // ADDED THE FOLLOWING LINE
                options: new CompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            using (var file = new FileStream(outputFile, FileMode.Create))
            {
                EmitResult result = compilation.Emit(file);
            }
            Assembly assembly = Assembly.LoadFrom("Greeter.dll");
            Type type = assembly.GetType("Greeter");
            var obj = Activator.CreateInstance(type);
            type.InvokeMember("Greet",
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                obj,
                null);
            Console.WriteLine("<ENTER> to continue");
            Console.ReadLine();
