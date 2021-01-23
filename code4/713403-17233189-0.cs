            class MyStructure
        {
            public string Foo { get; set; }
            public string Bar { get; set; }
        }
        public static void Main(string[] args)
        {
            var list = new List<MyStructure>();
            NameValueCollection nameValueCollection = new NameValueCollection();
            list.ForEach(x => {
                nameValueCollection.Add(x.Foo, x.Bar);
            });
            
        }
