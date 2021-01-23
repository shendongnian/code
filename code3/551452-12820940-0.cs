    public class MyComparer : IComparer<MyClass>
    {
    
        public int Compare(MyClass x, MyClass y)
        {
            if(x.Field1 != y.Field1)
                return x.Field1.CompareTo(y.Field1)
            else
                return x.Field2.CompareTo(y.Field2);
        }
    }
    
    List<MyClass> list = new List<MyClass>();
    //Populate list
    
    list.Sort(new MyComparer());
