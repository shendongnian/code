    public class MyList : List<string>
    {
        public string DoSomething()
        {
            return "Something";
        }
    }
    //...
    List<string> l = new List<string>();
    ((MyList)l).DoSomething(); // ERROR - List<string> does not define DoSomething()!
