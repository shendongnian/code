    class A
    {
        private static void Main(string[] args)
        {
            Passing passing = new Passing("Hello World");
            Console.WriteLine(passing);
         }
    }
    class Passing
    {
        public Passing(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }
    }
