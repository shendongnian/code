    public class MyObject
    {
        public MyObject(String v)
        {
            Value = v;
        }
        public String Value { get; set; }
    }
    MyObject a = new MyObject("a");
    MyObject b = new MyObject("a");
    if(a==b){
        Debug.WriteLine("a reference is equal to b reference");
    }else{
        Debug.WriteLine("a reference is not equal to b reference");
    }
    if (a.Equals(b)) {
        Debug.WriteLine("a object is equal to b object");
    } else {
        Debug.WriteLine("a object is not equal to b object");
    }
