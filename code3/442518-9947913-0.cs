    public class MyServer
    {
        public string Name { get; private set };
        public string OS { get; private set };
        public string Product { get; private set };
        public MyServer(string name, string os, string product)
        {
            this.Name = name;
            this.OS = os;
            this.Product = product;
        }
    }
