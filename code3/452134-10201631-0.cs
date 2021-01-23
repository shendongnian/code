    public class MyEntityClass
    {
        private int _isNew;
        private int _isDirty;
        private int _pkValue;
        private string _colValue;
        public MyEntityClass()
        {
            _isNew = true;
        }
        public int PKValue
        {
            get {return _pkValue;}
        }
        public string ColValue
        {
            get {return _colValue;}
            set
            {
                if (value != _colValue)
                {
                    _colValue = value;
                    _isDirty = true;
                }
            }
        }
        public void Load(int pkValue)
        {
            _pkValue = pkValue;
            //TODO: query database and set member vars based on results (_colVal)
            // if data found
            _isNew = false;
            _isDirty = false;
        }
        public void Save()
        {
            if (_isNew)
            {
                //TODO: insert record into DB
                //TODO: return DB generated PK ID value from SP/query, and set to _pkValue
            }
            else if (_isDirty)
            {
                //TODO: update record in DB
            }
        }
    }
