    public List<string> ExportEnumToList(<enum choice> enumName)    {
	List<string> enumList = new List<string>();
	//TODO: Do something here which I don't know how to do it.
	foreach (YourEnum item in Enum.GetValues(typeof(YourEnum ))){
		enumList.Add(item);
	}
	return enumList;    
}
