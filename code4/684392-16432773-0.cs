    public class MyObj
    {
        public int column1;
        public int column2;
        public string column3;
        public MyObj(int col1, int col2, string col3)
        {
            column1 = col1;
            column2 = col2;
            column3 = col3;
        }
    }
    public class MyList
    {
        public System.Collections.Generic.List<MyObj> List = new List<MyObj>();
        public void Add(MyObj obj)
        {
            List.Add(obj);
        }
    }
    public class ProgramTest
    {
        public static void Main(string[] args)
        {
            MyList list = new MyList();
            list.Add(new MyObj(1, 807301, "miama"));
            list.Add(new MyObj(1, 807301, "Test2"));
            list.Add(new MyObj(1, 807301, "Test3"));
            list.Add(new MyObj(1, 807301, "Test4"));
            //test
            foreach (MyObj o in list.List)
            {
                Console.WriteLine(o.column1);
            }
        }
    }
