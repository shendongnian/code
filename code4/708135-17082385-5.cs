    public class MyObject
    {
       public bool Available;
    }
    ...
    var result = objectList.Where(x => x.Available && IsOnline(x));
