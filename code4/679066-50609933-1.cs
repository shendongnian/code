         public MyEntities(string connectionString)
            : base(connectionString)
        {
            Set1 = Set<MyDbSet1>();
            Set2 = Set<MyDbSet2>();
        }
