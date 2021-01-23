    class Program
    {
        static void Main(string[] args)
        {
            Entity e = new Entity();
            e.@do = 10;
        }
    }
    class Entity
    {
        public int @do
        {
            get;
            set;
        }
    }
