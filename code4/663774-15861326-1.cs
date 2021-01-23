    public class MyViewModel
    {
        private MyCollection<int> _values;
        public MyViewModel()
        {
            _values = new MyCollection<int>() { 1, 2, 3, 4, 5 };
        }
        public MyCollection<int> Values
        {
            get { return _values; }
        }
    }
