    class JMessage
    {
        public Type Type { get; set; }
        public JToken Value { get; set; }
        public static JMessage FromValue<T>(T value)
        {
            return new JMessage { Type = typeof(T), Value = JToken.FromObject(value) };
        }
        public static string Serialize(JMessage message)
        {
            return JToken.FromObject(message).ToString();
        }
        public static JMessage Deserialize(string data)
        {
            return JToken.Parse(data).ToObject<JMessage>();
        }
    }
