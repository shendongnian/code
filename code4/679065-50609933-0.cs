        public MyEntities()
            : base("name=MyEntity")
        {
            Set1 = Set<MyDbSet1>();
            Set2 = Set<MyDbSet2>();
        }
