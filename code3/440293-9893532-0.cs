	static class ZipCodes: INotifyPropertyChanged
	{
    #region Methods
    public static string GetValue(string key)
    {
        string result;
        if (zipCodeDictionary.TryGetValue(key, out result))
        {
            return result;
        }
        else
        {
            return null;
        }
    }
    public static int GetCount()
    {
        return zipCodeDictionary.Count();
    }
    #endregion
	
	#region property
	private static int progress=0;
	Public static int LoadingProgress
	{
		get
		{
		return progress;
		}
		set
		{
		if(value!=progress)
			{
				progress = value;
				NotifyPropertyChanged("LoadingProgress");
			}
		}
	}	
	#endregion
	
	#region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
	#endregion
    #region ZipCode Dictionary Definition
    static Dictionary<string, string> zipCodeDictionary = new Dictionary<string, string>();
    public static void PopulateZipCodeDictionary()
    {
        zipCodeDictionary.Add( "00501", "Holtsville, NY" );
		LoadingProgress++;
        zipCodeDictionary.Add( "00544", "Holtsville, NY" );
		LoadingProgress++;
        zipCodeDictionary.Add( "00601", "Adjuntas, PR" );
		LoadingProgress++;
