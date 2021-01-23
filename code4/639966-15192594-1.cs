    class ListItemsHelper
    {
    	private const string FILE_NAME = "items.dat";
    
    	public static void SaveData(Items items)
    	{
    		string data = SerializeItems(items);
    		File.WriteAllText(GetFilePath(), data);
    	}
    
    	public static Items LoadData()
    	{
    		string data = File.ReadAllText(GetFilePath());
    		return DeserializeItems(data);
    	}
    
    	private static string GetFilePath()
    	{
    		return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILE_NAME);
    	}
        private string SerializeItems(Items items)
        {
            //Do serialization here
        }
    
        private Items DeserializeItems(string data)
        {
            //Do deserialization here
        }
    }
