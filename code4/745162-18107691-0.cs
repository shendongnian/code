    [DataContract]
    public abstract class Dirty : Object
    {
        protected bool _isdirty;
        public bool IsDirty
        {
            get { return _isdirty; }
            set
            {
                _isdirty = value;
            }
    
    }
    
    public abstract class DataStore<T> where T : Dirty
    {
        private string _path;
        private string _tempFile;
    
        protected DataStore(string path, string tempfile)
        {
           
            _path = path;
            _tempFile = tempfile;
        }
    }
