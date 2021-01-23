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
                return _errorInfo.ContainsKey(columnName) ? _errorInfo[columnName] : null;
            }
        }
        public string FirstName
        {
            get { return _firstName;}
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    _errorInfo.AddOrUpdate("FirstName", "Geef een voornaam in");
                else
                {
                    _errorInfo.Remove("FirstName");
                    _firstName = value;
                }
            }
        }
    }
