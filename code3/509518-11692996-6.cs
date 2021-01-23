    public class MyBigClass
    {
        private List<int> myList;
        public MyBigClass()
        {
            //instantiate list in constructor
            myList = new List<int>() { 1, 2, 3, 4 }; 
        }
    
        public void PublicListAdder(int val)
        {
            myList.Add(val);
        }
    
        private void PrivateListCleaner()
        {
            //remove all even numbers, just an example
            myList.RemoveAll(x => x % 2 == 0);
        }
    }
