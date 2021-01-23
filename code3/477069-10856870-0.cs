        static void Main(string[] args)
        {
            Dictionary<string, IRootCollection> values = new Dictionary<string, IRootCollection>();
            values["strings"] = new RootCollection<string>();
            (values["strings"] as RootCollection<string>).Add("foo");
            (values["strings"] as RootCollection<string>).Add("bar");
            values["ints"] = new RootCollection<int>();
            (values["ints"] as RootCollection<int>).Add(45);
            (values["ints"] as RootCollection<int>).Add(86);
        }
        interface IRootCollection { }
        class RootCollection<T> : List<T>, IRootCollection { }
