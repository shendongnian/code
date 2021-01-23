    public class TestObjectGraph
    {
        public MyEntity RootEntity()
        {
            var root = new MyEntity
            {
                Name = "Earth",
                Children =
                    new List<MyEntity>
                        {
                            new MyEntity
                            {
                                Name = "Europe",
                                Children =
                                    new List<MyEntity>
                                    {
                                        new MyEntity {Name = "Germany"},
                                        new MyEntity
                                        {
                                            Name = "Ireland",
                                            Children =
                                                new List<MyEntity>
                                                {
                                                    new MyEntity {Name = "Dublin"},
                                                    new MyEntity {Name = "Belfast"}
                                                }
                                        }
                                    }
                            },
                            new MyEntity
                            {
                                Name = "South America",
                                Children =
                                    new List<MyEntity>
                                    {
                                        new MyEntity
                                        {
                                            Name = "Brazil",
                                            Children = new List<MyEntity>
                                            {
                                                new MyEntity {Name = "Rio de Janeiro"}
                                            }
                                        },
                                        new MyEntity {Name = "Chile"},
                                        new MyEntity {Name = "Argentina"}
                                    }
                            }
                        }
            };
    
            return root;
        }
    }
