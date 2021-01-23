    public class First
    {
        public ArrayList MyList;
        public First()
        {
           MyList = new ArrayList();
        }
        public void AddString(string str)
        {
           MyList.Add(str);
        }
    }
    public class Second
    {
        public void someMethod()
        {
           First f = new First();
           f.AddString("test1");
           f.AddString("test2");
           f.AddString("test3");
           ArrayList aL = f.MyList; // you will get updated array list object here.
        }
    }
