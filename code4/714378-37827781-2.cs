    public class JsonCached
    {
    	public static async Task<string> ImageFromCache2(string path)
    	{
    		int ru = path.IndexOf(".ru") + 4;// TODO: .com .net .org
    		string new_path = path.Substring(ru).Replace("/", "\\");
    
    		StorageFolder localFolder = ApplicationData.Current.LocalFolder;
    		try
    		{
    			Stream p = await localFolder.OpenStreamForReadAsync(new_path);
    			p.Dispose();
    			System.Diagnostics.Debug.WriteLine("From cache");
    			return localFolder.Path + "\\" + new_path;
    		}
    		catch (FileNotFoundException)
    		{
    
    		}
    		catch (Exception e)
    		{
    			System.Diagnostics.Debug.WriteLine("{0}", e.Message);
    		}
    
    		StorageFile storageFile = await localFolder.CreateFileAsync(new_path, CreationCollisionOption.OpenIfExists);
    
    		Uri Website = new Uri(path);
    		HttpClient http = new HttpClient();
    		// TODO: Check connection. Return message on fail.
    		System.Diagnostics.Debug.WriteLine("Downloading started");
    		byte[] image_from_web_as_bytes = await http.GetByteArrayAsync(Website);
    
    		MakeFolders(localFolder, path.Substring(ru));
    
    		Stream outputStream = await storageFile.OpenStreamForWriteAsync();
    		outputStream.Write(image_from_web_as_bytes, 0, image_from_web_as_bytes.Length);
    		outputStream.Position = 0;
    		
    		System.Diagnostics.Debug.WriteLine("Write file done {0}", outputStream.Length);
    
    		outputStream.Dispose();
    		return localFolder.Path + "\\" + new_path;
    	}
    
    	private static async void MakeFolders(StorageFolder localFolder, string path)
    	{
    		//pics/thumbnail/050/197/50197442.jpg
    		int slash = path.IndexOf("/");
    		if (slash <= 0) // -1 Not found
    			return;
    
    		string new_path = path.Substring(0, slash);
    		StorageFolder opened_folder = await localFolder.CreateFolderAsync(new_path, CreationCollisionOption.OpenIfExists);
    		string very_new_path = path.Remove(0, new_path.Length + 1);
    		MakeFolders(opened_folder, very_new_path);
    	}
    }
