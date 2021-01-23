            List<MyEntity> list1 = new List<MyEntity>();
            List<MyEntity> list2 = new List<MyEntity>();
            List<MyEntity> addedList = new List<MyEntity>();
            list1.Add(new MyEntity()
            {
                Name = "A",
                Value = 1
            });
            list1.Add(new MyEntity()
            {
                Name = "B",
                Value = 1
            });
            list2.Add(new MyEntity()
            {
                Name = "A",
                Value = 2
            });
            addedList = list1.AddList(list2);
