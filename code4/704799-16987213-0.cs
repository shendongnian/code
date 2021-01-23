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
            private static Type  GetType(string type)
            {
                CommonScriptEngine engine = new ScriptEngine();
                string[] defaultReferences = new string[] { "System" };
                string[] defaultNamespaces = new string[] { "System", "System.Collections.Generic" };
                foreach (var reference in defaultReferences)
                {
                    engine.AddReference(reference);
                }
                foreach (var nameSpace in defaultNamespaces)
                {
                    engine.ImportNamespace(nameSpace);
                }
                var session = engine.CreateSession();
                var result=session.Execute("Type foo(){return typeof("+type+");}foo();");
                return result as Type;
            }
        }
    }
