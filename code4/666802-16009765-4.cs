        public class FileHelper 
        {
        	public static string ReadAllText(string filePath)
        	{
        		var path = filePath.GetFullPath();
        		if (!File.Exists(path))
        		{
        			Logging.LogHandler.LogError("File " + path + " does not exists");
                    return string.Empty;
        		}
        		using (var reader = new StreamReader(filePath))
        		{
        			return reader.ReadToEnd();
        		}
        	}
       }
