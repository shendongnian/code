    public class MyObject
    {
    private TimeSpan _myTimeSpan;
   
    // ...
    public string TimeSpanFormatted
    {
        get
        {
             return _myTimeSpan.ToString("c");
        }
    }
   
    // ...
    }
