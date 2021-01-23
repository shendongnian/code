    Dictionary<string, string> _VendorData;
    public object VendorData
    {
      get
      {
        if (_VendorData == null)
          _VendorData = GetVendorDictionary();
        return _VendorData;
      }
    }
    public Dictionary<string, string> GetVendorDictionary()
    {
      //get vendor data from database and populate a dictionary
    }
