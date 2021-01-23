    public class MyClass
        {
            public int ID { get; set; }
            public override bool Equals(object obj)
            {
                return this.ID == ((MyClass)obj).ID;
            }
            public override int GetHashCode()
            {
                return ID.GetHashCode();
            }
        }
    var lst1 = new List<MyClass> { new MyClass { ID = 1 }, new MyClass { ID = 2 }, new MyClass { ID = 3 } };
    var lst2 = new List<MyClass> { new MyClass { ID = 3 }, new MyClass { ID = 4 }, new MyClass { ID = 5 } };
    var newList = lst1.Union(lst2);
    foreach (var myClass in newList)
        {
            Console.WriteLine("ID: {0}", myClass.ID);
            }
