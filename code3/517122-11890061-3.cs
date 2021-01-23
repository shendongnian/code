            List<MyEntity> AllMyEntities = new List<MyEntity>();
            AllMyEntities.Add(new MyEntity("1", 1, null));
            AllMyEntities.Add(new MyEntity("1.1", 2, 1));
            AllMyEntities.Add(new MyEntity("1.1.1", 3, 2));
            AllMyEntities.Add(new MyEntity("2", 4, null));
            AllMyEntities.Add(new MyEntity("2.1", 5, 4));
            Console.Write(GetFamilyTree(AllMyEntities).ToString());
