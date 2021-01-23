    void Main()
    {
        var myVar = returnObjectOrNull() ?? new MyObject();
    }
    
    public MyObject returnObjectOrNull()
    {
        return new MyObject();
    }
    
    public class MyObject
    {
        public MyObject()
        {
            Debug.WriteLine("MyObject created");
        }
    }
