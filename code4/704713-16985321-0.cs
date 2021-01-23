    public SomeTableRepository
    {
        private SomeTable _someTable;
    
        public SomeTable {
            get {
              if (_someTable != null)
                  return _someTable;
              else if (Session["SomeTable"] != null)
    
                  return (SomeTable)Session["SomeTable"];
              else
              {
                  _someTable = GetDataFromDatabase();
                  Session["SomeTable"] = _someTable;
                  return _someTable;
              }
            }
            set {
                _someTable = value;
                Session["SomeTable"] = _someTable;
            }
        }
    }
