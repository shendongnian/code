    using System.ComponentModel;
    <#=codeStringGenerator.EntityClassOpening(entity)#>
    {
    <#
    var propertiesWithDefaultValues = typeMapper.GetPropertiesWithDefaultValues(entity);
    var collectionNavigationProperties = typeMapper.GetCollectionNavigationProperties(entity);
    var complexProperties = typeMapper.GetComplexProperties(entity);
	#>
	public event PropertyChangedEventHandler PropertyChanged;
	protected virtual void OnPropertyChanged(string propertyName)
    {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
	
