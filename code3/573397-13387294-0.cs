    public partial class Player : IDataErrorInfo
    {
        Dictionary<string, string> _errorInfo;
        public Player()
        {
            _errorInfo = new Dictionary<string, string>();
        }
        public bool CanSave { get { return _errorInfo.Count == 0; }
        public string this[string columnName]
        {
            get 
            { 
                if ( _errorInfo.ContainsKey(columnName))
                { 
                    return _errorInfo[columnName];
                }
                return null;
            }
        }
        public string FirstName
        {
            get { return _firstName;}
            set
            {
                _firstName = value;
                if (String.IsNullOrWhiteSpace(Firstname))
                {
                    _errorInfo.AddOrUpdate("FirstName", "Geef een voornaam in");
                }
                else
                {
                    _errorInfo.Remove("FirstName");
                }
            }
        }
    }
