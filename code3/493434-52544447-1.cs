    public class FooCollection : System.Collections<Foo>
    {
        //...
        protected override void InsertItem(int index, Foo newItem)
        {
            base.InsertItem(index, newItem);     
            Console.Write("An item was successfully inserted to MyCollection!");
        }
    }
    public static void Main()
    {
        MyCollection myCollection = new MyCollection();
        myCollection.Add(new Foo()); //OUTPUT: An item was successfully inserted to MyCollection!
    }
