    public class MyClass : IComparable<MyClass>
    {
        int IComparable<MyClass>.CompareTo(MyClass other)
        {
            // DoCompareFunction(this, other); and return -1,0,1
        }
    }
