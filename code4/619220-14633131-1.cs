        private class Foo
        {
            public DateTime Date { get; set; }
            public int Id { get; set; }
        }
        static void Main(string[] args)
        {
            var myList = new List<Foo>
                             {
                                 new Foo {Date = new DateTime(2012, 01, 01), Id = 12},
                                 new Foo {Date = new DateTime(2012, 01, 01), Id = 1},
                                 new Foo {Date = new DateTime(2012, 01, 03), Id = 7},
                                 new Foo {Date = new DateTime(2012, 01, 01), Id = 4},
                             };
            var newList = myList.OrderBy(v => v.Date).ThenBy(v => v.Id).ToList();
            foreach (var f in newList)
            {
                Console.WriteLine("{0}, {1}", f.Date, f.Id);
            }
            Console.ReadLine();
        }
