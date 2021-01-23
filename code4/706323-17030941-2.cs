    public List<double> _newData;
    public List<double> NewData
    {
        get
        {
            if(_newData == null)
                _newData = new List<double>();
            return _newData;
        }
    }
