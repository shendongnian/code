    public class CustomObject
    {
        private List<string> _listProperty = new List<string>(new string[]{"One","Two","Three"});
        public List<string> ListProperty
        {
            get { return _listProperty; }
            set { _listProperty = value; }
        }
        
    }
   
