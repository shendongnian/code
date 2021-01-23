        static void Main(string[] args)
        {
            string[] listOne = new [] { "test1", "test2", "test3" };
            MyClass[] listTwo = new [] { new MyClass("test1") };
            string[] newVals = (from str1 in listOne
                               join str2 in  listTwo.Select(e => e.Name) on str1 equals str2
                               select str1).ToArray();
            foreach (var newVal in newVals)
            {
                Console.WriteLine(newVal);
            }
            //string[] newVals2 = listOne.Intersect(listTwo.Select(t => t.Name)).ToArray();
        }
        class MyClass
        {
            public MyClass(string name)
            {
                Name = name;
            }
            public string Name { get; set; }
        }
