    class JsonTemplateVisitor : JsonVisitor
    {
        private readonly object m_data;
        private JsonTemplateVisitor(object data)
        {
            m_data = data;
        }
        public static JToken Serialize(object data, string templateString)
        {
            return Serialize(
                data, (JToken)JsonConvert.DeserializeObject(templateString));
        }
        public static JToken Serialize(object data, JToken template)
        {
            var visitor = new JsonTemplateVisitor(data);
            return visitor.Visit(template);
        }
        protected override JToken VisitValue(JValue value)
        {
            if (value.Type == JTokenType.String)
            {
                var s = (string)value.Value;
                if (s.StartsWith("$"))
                {
                    string path = s.Substring(1);
                    var newValue = GetValue(m_data, path);
                    var newValueToken = new JValue(newValue);
                    value.Replace(newValueToken);
                    return newValueToken;
                }
            }
            return value;
        }
        private static object GetValue(object data, string path)
        {
            var parts = path.Split('.');
            foreach (var part in parts)
            {
                if (data == null)
                    break;
                data = data.GetType()
                    .GetProperty(part)
                    .GetValue(data, null);
            }
            return data;
        }
    }
