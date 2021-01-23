        public class Parent
        {
            public Parent(string id)
            {
                Id = id;
            }
    
            public string Id { get; set; }
        }
    
        public class Child : Parent
        {
            public Child(string id, string name)
                : base(id)
            {
                name = Name;
            }
    
            public string Name { get; set; }
        }
