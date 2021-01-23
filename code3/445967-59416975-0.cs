    public struct ImmutableData
    {
        private readonly int data;
        private readonly string name;
        public ImmutableData(int data, string name)
        {
            this.data = data;
            this.name = name;
        }
        public int Data { get => data; }
        public string Name { get => name; }
        public void SetName(string newName)
        {
            // this wont work
            // this.name = name; 
            // but this will
            this = new ImmutableData(this.data, newName);
        }
        public override string ToString() => $"Data={data}, Name={name}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var X = new ImmutableData(100, "Jane");
            X.SetName("Anne");
            Debug.WriteLine(X);
            // "Data=100, Name=Anne"
        }
    }
