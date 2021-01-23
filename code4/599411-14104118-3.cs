	private ProjectType _selectedItem'
	public string SelectedItem
	{
	   get
		{
		  return ConvertEnumToString(_selectedItem);
		}
		set
		{
		  _selectedItem = ConvertStringToEnum(value);
		}
	}
	public static string ConvertEnumToString(Enum eEnum)
    {
        return Enum.GetName(eEnum.GetType(), eEnum);
    }
	
	public static ProjectType ConvertStringToEnum(string value)
    {
        return (ProjectType)Enum.Parse(typeof(ProjectType), value);
    }
	
	
