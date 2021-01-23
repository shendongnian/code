    public sealed class Lock
    {
        private readonly string name;
        public string Name { get { return name; } }
        public Lock(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            this.name = name;
        }
    }
