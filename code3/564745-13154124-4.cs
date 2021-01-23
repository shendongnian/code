    private List<IMyBusinessObjectType> _businessObjects= new List<IMyBusinessObjectType>();
    private ReadOnlyCollection<IMyBusinessObjectType> _readOnlybusinessObjects;
    public ReadOnlyCollection<IMyBusinessObjectType> BusinessObjects
    {
        get
        {
            if(_readOnlybusinessObjects==null)
                _readOnlybusinessObjects=new ReadOnlyCollection<IMyBusinessObjectType>(_businessObjects);
            return _readOnlybusinessObjects;
        }
    }
