    public class SessionData
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Type { get; private set; }
        public SessionData(int id, string name, int type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
