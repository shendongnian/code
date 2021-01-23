    class MyList
    {
        // private now
        readonly SortedList<int, List<myObj>> CharList;
        // public indexer
        public List<myObj> this[int index]
        {
            get { return this.CharList[index]; }
        }
    }
