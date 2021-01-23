    public class FinalList
    {
        private Chart _chart;
        private List<Data> _data = new List<Data>();
        public Chart chart
        {
            get { return _chart; }
            set { _chart = value; }
        }
        public List<Data> data
        {
            get { return _data; }
            set { _data = value; }
        }
        protected internal FinalList() { }
    }
