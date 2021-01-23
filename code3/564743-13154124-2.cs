    private List<MyBusinessObjectType> _businessObjects= new List<MyBusinessObjectType>();
    private ReadOnlyCollection<MyBusinessObjectType> _readOnlybusinessObjects;
    public ReadOnlyCollection<MyBusinessObjectType> BusinessObjects
    {
        get
        {
            if(_readOnlybusinessObjects==null)
                _readOnlybusinessObjects=new ReadOnlyCollection<MyBusinessObjectType>(_businessObjects);
            return _readOnlybusinessObjects;
        }
    }
