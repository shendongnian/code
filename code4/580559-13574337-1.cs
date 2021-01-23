    private IUnitDataProvider _unitDataProvider;
    public templateClass(IUnitDataProvider provider)
    {
            _unitDataProvider=provider
    }
    public void CreateTemplate(Template template)
    {
        //pre -addUnit code here
       _unitDataProvider.AddChildrenUnit(unit, connectionstring);
        //Post -addUnit code here
    }
    
