    public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var keyedBindingList = new FastLookupBindingList<int, Person>(p => p.Id)
                                       {
                                           new Person {Id = 1, Name = "Joe"}, 
                                           new Person {Id = 2, Name = "Josephine"}
                                       };
            var person = keyedBindingList.FastFind(2);
            var unkonwn = keyedBindingList.FastFind(4);
        }
