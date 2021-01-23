    using Roslyn.Scripting;
    using Roslyn.Scripting.CSharp;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(GetType("int[,][,][][,][][]"));
                Console.WriteLine(GetType("Activator"));
                Console.WriteLine(GetType("List<int[,][,][][,][][]>"));
            }
            private static Type GetType(string type)
            {
                var engine = new ScriptEngine();
                new[] { "System" }
                    .ToList().ForEach(r => engine.AddReference(r));
                new[] { "System", "System.Collections.Generic" }
                    .ToList().ForEach(ns => engine.ImportNamespace(ns));
                return engine
                    .CreateSession()
                    .Execute<Type>("typeof(" + type + ")");
            }
        }
    }
