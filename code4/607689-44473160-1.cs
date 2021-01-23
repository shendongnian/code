    public class MyClass : IComparer<MyClass>
    {
        int IComparable<MyClass>.Compare(MyClass x, MyClass y)
        {
            // DoCompareFunction(x, y); and return -1,0,1
        }
    }
