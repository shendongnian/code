    class ObjectWrapper
    {
        private object _value;
        
        public ObjectWrapper(object value) 
        {
            _value = value;
        }
        public override string ToString()
        {
            return _value.ToString();
        }
    }
    static class TranslationParser
    {
        private const string regex = "{([a-z]+)}";
        private static Dictionary<string, ObjectWrapper> variables = new Dictionary<string, ObjectWrapper>();
    
        public static void RegisterVariable(string name, object value)
        {
            var wrapped = new ObjectWrapper(value);
            if (variables.ContainsKey(name))
                variables[name] = wrapped;
            else
                variables.Add(name, wrapped);
        }
    
        public static string ParseText(string text)
        {
            return Regex.Replace(text, regex, match =>
            {
                string varName = match.Groups[1].Value;
    
                if (variables.ContainsKey(varName))
                    return variables[varName].ToString();
                else
                    return match.Value;
            });
        }
    }
