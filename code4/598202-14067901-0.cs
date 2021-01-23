    public class clsCountry
    {
        public string _CountryCode;
        public string _CountryName;
        //
        public clsCountry(string strCode, string strName)
        {
            this._CountryCode = strCode;
            this._CountryName = strName;
        }
        //
        public string CountryCode
        {
            get {return _CountryCode;}
            set {_CountryCode = value;}
        }
        //
        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }
    }
    
