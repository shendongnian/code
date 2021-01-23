    public class MyObject
    {
       public bool Available;
       public bool Online { get { return MyObjectHelper.IsOnline(this); } }
    }
    ...
    var result = objectList.Where(x => x.Available && x.Online);
