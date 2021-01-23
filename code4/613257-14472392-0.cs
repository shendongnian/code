    class MyClass
    {
        Dictionary<string, List<string>> myD;        
        List <string> MyList;
        public MyClass()
        {
            MyList = new List<string>() { "1" };
            myD = new Dictionary<string, List<string>>()
            {
              {"tab1", MyList }
            };
        }
    }
