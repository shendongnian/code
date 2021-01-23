    [System.Serializable]
    internal sealed class SaveAndLoadItem {
	public SaveAndLoadItem(){
		UniqueName = "--Nothing--";
		Value = null;
		ValueType = null;	
		IsClient = false;
	}
	public SaveAndLoadItem(string uniqueName, object value,Type typeOfValue,bool isClient){
		UniqueName = uniqueName;
		Value = value;
		ValueType = typeOfValue;
		IsClient = isClient;
	}
	
    public string UniqueName;
    public System.Object Value;
    public Type   ValueType;
	public bool   IsClient;
	
}
