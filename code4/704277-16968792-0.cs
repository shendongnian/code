    protected SPList createNewList(SPFeatureReceiverProperties properties)
    {
        //Do the stuff
        SPList result = new SPAPI.Lists.Create(properties, param, "Fake List", "Sample Description", SPListTemplateType.GenericList, "Sample View Description");
        return result;
    }
    public SPList Create(SPFeatureReceiverProperties properties, Dictionary<string, List<AddParams>> columns, 
        string name, string description, SPListTemplateType type, string viewDescription)
    {
        // Do the stuff
        return spList;
    }
