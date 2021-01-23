    public class IronPythonScriptEvaluator
    {
        private Lazy<ScriptEngine> engine = new Lazy<ScriptEngine>(() => Python.CreateEngine());
        private ScriptEngine Engine { get { return engine.Value; } }
        
        private const string ItemName = "_IronPythonScriptEvaluator_item";
        
        public object EvaluateScript(string script, object value, string context)
        {
            var cleanScript = CleanupScript(script);
            var scope = Engine.CreateScope();
            scope.SetVariable(ItemName, value);
            return Engine.Execute<bool>(cleanScript, scope);
        }
        
        private string CleanupScript(string script)
        {
            return Regex.Replace(script, @"@", ItemName);
        }
    }
