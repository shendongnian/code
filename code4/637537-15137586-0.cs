    [Serializable]
    public class UserData : ISerializable
    {
        public string Text { get; private set; }
        public int Number { get; private set; }
        public UserData(string text, int number)
        {
            Text = text;
            Number = number;
        }
        protected UserData(SerializationInfo info, StreamingContext context)
        {
            Text = info.GetString("Text");
            Number = info.GetInt32("Number");
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Text", Text);
            info.AddValue("Number", Number);
        }
    }
