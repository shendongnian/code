    class MyObjects : IEnumerable<MyObject>
    {
        List<MyObject> mylist = new List<MyObject>();
        public MyObject this[int index]  
        {  
            get { return mylist[index]; }  
            set { mylist.Insert(index, value); }  
        } 
        public IEnumerator<MyObject> GetEnumerator()
        {
            return mylist.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mylist.GetEnumerator();
        }
    }
