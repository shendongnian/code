            var iters = 300;
            foreach (var i in Enumerable.Range(0, iters))
            {
                // Parse the source file using Roslyn
                SyntaxTree syntaxTree = SyntaxTree.ParseText(@"public class Foo" + i + @" { public void Exec() { } }");
                // Add all the references we need for the compilation
                var references = new List<MetadataReference>();
                references.Add(new MetadataFileReference(typeof(int).Assembly.Location));
                var compilationOptions = new CompilationOptions(outputKind: OutputKind.DynamicallyLinkedLibrary);
                // Note: using a fixed assembly name, which doesn't matter as long as we don't expect cross references of generated assemblies
                var compilation = Compilation.Create("SomeAssemblyName", compilationOptions, new[] { syntaxTree }, references);
                var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new System.Reflection.AssemblyName("CustomerA"),
                System.Reflection.Emit.AssemblyBuilderAccess.RunAndCollect);
                var moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule");
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                // if we comment out from this line and down, the runtime drops to ~.5 seconds
                var emitResult = compilation.Emit(moduleBuilder);
                watch.Stop();
                System.Diagnostics.Debug.WriteLine(watch.ElapsedMilliseconds);
                if (emitResult.Diagnostics.LongCount() == 0)
                {
                    var type = moduleBuilder.GetTypes().Single(t => t.Name == "Foo" + i);
                    
                    System.Diagnostics.Debug.Write(type != null);
                }
            }
