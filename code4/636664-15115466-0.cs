    public class MyClass 
    {
        private List<int> _InternalList = new List<int>();
    
        public int this[int i]
        {
            get { return _InternalList[i]; }
            set { _InternalList[i] = value; }
        }
    }
