    class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    class MyObject
    {
        public IEnumerable<Service> Services { get; set; }
    }
    class MyObjects : List<MyObject>
    {
    }
