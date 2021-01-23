    class Program
    {
        static List<string> MyList = MyClass.MyList;
        static void Main(string[] args)
        {
            MyList.Add("Some value.");
        }
    }
