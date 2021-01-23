    public List<vcData> GetTableData()
    {
        var currentMergeOption =  _entities.vcData.MergeOption;
        _entities.vcData.MergeOption = MergeOption.OverwriteChanges;
        var result = (from td in _entities.vcData
                      where td.SiteID == "MySite" 
                      select td).ToList();
        //revert the change
        _entities.vcData.MergeOption = currentMergeOption;
        return result;
    } 
