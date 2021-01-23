    public class SomeCLass
            {
                public int ID { get; set; }
                public string Name { get; set; }
            }
    
            public class AnotherClass
            {
                public int ID { get; set; }
                public int Value { get; set; }
                public int AnotherValue { get; set; }
            }
    public void TestMEthod()
            {
                List<SomeCLass> _assignmentControls = new List<SomeCLass>()
                    {
                        new SomeCLass() { ID = 1, Name = "test"},
                        new SomeCLass() { ID = 2, Name = "another test"}
                    };
                List<AnotherClass> _priceLevels = new List<AnotherClass>()
                    {
                        new AnotherClass() {ID = 1, AnotherValue = 15, Value = 13},
                        new AnotherClass() {ID = 2, AnotherValue = 5, Value = 13}
                    };
    
    
                var sortedList =
                //here you're declaring variable a that will be like caret when you going through _assignmentControls
                from a in _assignmentControls
                join p in _priceLevels on a.ID equals p.ID
                orderby p.AnotherValue
                select a;
                
                foreach (var someCLass in sortedList)
                {
                    Console.WriteLine(someCLass.Name);
                }
            }
