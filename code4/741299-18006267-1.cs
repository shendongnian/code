    class MyList : IList<string>
    {
        private readonly List<string> theList;
        public MyList(List<string> list)
        {
            theList = list;
        }
        // Implement the IList<string> interface by
        // calling the same methods on theList
    }
    List<string> oldList = new List<string>();
    MyList wrapper = new MyList(oldList);
