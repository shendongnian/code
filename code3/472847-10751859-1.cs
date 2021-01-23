    using System;
    
    using Roslyn.Compilers;
    using Roslyn.Compilers.CSharp;
    
    using System.IO;
    using System.Reflection;
    using System.Linq;
    
    namespace LoadingAClass
    {
        class Program
        {
            static void Main(string[] args)
            {
                var syntaxTree = SyntaxTree.ParseCompilationUnit(@"
    using System;
    namespace HelloWorld
    {
        class Greeter
        {
            public static void Greet()
            {
                Console.WriteLine(""Hello, World"");
            }
        }
    }");
    
                string dllPath = Path.Combine(Directory.GetCurrentDirectory(), "Greeter.dll");
                string pdbPath = Path.Combine(Directory.GetCurrentDirectory(), "Greeter.pdb");
    
                var compilation = Compilation.Create(dllPath,
                    new CompilationOptions(
                        assemblyKind: AssemblyKind.DynamicallyLinkedLibrary
                    ))
                    .AddSyntaxTrees( syntaxTree )
                    .AddReferences(new AssemblyFileReference(typeof(object).Assembly.Location))
                    .AddReferences(new AssemblyFileReference(typeof(Enumerable).Assembly.Location));
    
                EmitResult result;
    
                using (FileStream dllStream = new FileStream(dllPath, FileMode.OpenOrCreate))
                using (FileStream pdbStream = new FileStream(pdbPath, FileMode.OpenOrCreate))
                {
                    result = compilation.Emit(
                        executableStream: dllStream,
                        pdbFileName: pdbPath,
                        pdbStream: pdbStream);
                }
    
                if (result.Success)
                {
                    //assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), @"Greeter.dll"));
                    Assembly assembly = Assembly.LoadFrom(@"Greeter.dll");
    
                    Type type = assembly.GetType("HelloWorld.Greeter");
                    var obj = Activator.CreateInstance(type);
    
                    type.InvokeMember("Greet",
                        BindingFlags.Default | BindingFlags.InvokeMethod,
                        null,
                        obj,
                        null);
                }
                else
                {
                    Console.WriteLine("No Go");
                    Console.WriteLine(result.Diagnostics.ToString());
                }
    
                Console.WriteLine("<ENTER> to continue");
                Console.ReadLine();
    
            }
        }
        // Thanks, http://blogs.msdn.com/b/csharpfaq/archive/2011/11/23/using-the-roslyn-symbol-api.aspx
        // Thanks, http://social.msdn.microsoft.com/Forums/en-US/roslyn/thread/d620a4a1-3a90-401b-b946-bfa1fc6ad7a2
    }
