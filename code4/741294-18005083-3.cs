    public class ListInheritanceTest
    {
        public void Test1()
        {
            List<string> list = new List<string>();
            MyList myList = new MyList(list);  // copy the items in the list
        }
    }
    public class MyList : List<string>
    {
	   public MyList(IEnumerable<string> list) : base(list) {}  // reuse the List<T> copy constructor
    }
