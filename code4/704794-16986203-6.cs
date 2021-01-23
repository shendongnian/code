    using Roslyn.Scripting.CSharp;
        public static Type GetFriendlyType(string typeName)
        {
            ScriptEngine engine = new ScriptEngine();
            var type = engine.CreateSession()
                             .Execute<Type>(string.Format("typeof({0})", typeName));
            return type;
        }
