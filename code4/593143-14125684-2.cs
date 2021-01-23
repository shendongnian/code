            List<MyObject> listA = new List<MyObject>(){
                new MyObject() { Key = 1, Day = new DateTime(2012, 12, 17), Value = 8 },
                new MyObject() { Key = 2, Day = new DateTime(2012, 12, 17), Value = 8 },
                new MyObject() { Key = 1, Day = new DateTime(2012, 12, 18), Value = 8 },
                new MyObject() { Key = 4, Day = new DateTime(2012, 12, 17), Value = 4 },
                new MyObject() { Key = 3, Day = new DateTime(2012, 12, 17), Value = 4 }
            };
            List<MyObject> listB = new List<MyObject>(){
                new MyObject() { Key = 1, Day = new DateTime(2012, 12, 17), Value = 2 },
                new MyObject() { Key = 3, Day = new DateTime(2012, 12, 17), Value = 8 },
                new MyObject() { Key = 4, Day = new DateTime(2012, 12, 17), Value = 4 },
                new MyObject() { Key = 1, Day = new DateTime(2012, 12, 18), Value = 8 },
                new MyObject() { Key = 5, Day = new DateTime(2012, 12, 17), Value = 10 }
            };
            List<MyObject> listChanges = Comparer(listA, listB);
            MyObject[] hasil = listChanges.ToArray();
            for (int a = 0; a < hasil.Length;a++ ) {
                Console.WriteLine(hasil[a].Key+" "+hasil[a].Day+" "+hasil[a].Value);
            }
