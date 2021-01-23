    /// <summary>
    /// Handles data access for Url entities
    /// </summary>
    public static class UrlDAL
    {
    	/// <summary>
    	/// The path where the file resides
    	/// </summary>
    	const string __FilePath = @"~\App_Data\";
    	/// <summary>
    	/// The name of the file
    	/// </summary>
    	const string __FileName = "UrlList.xml";
    	/// <summary>
    	/// The name of the temporary file. Used to keep a copy of the file if saving the new file fails.
    	/// </summary>
    	const string __FileNameTemp = "UrlList_TEMP.xml";
    
    	/// <summary>
    	/// Retrieves a list of url entity objects
    	/// </summary>
    	/// <returns></returns>
    	internal static List<Url> Retrieve()
    	{
    		List<Url> urls = null;
    
    		try
    		{
    			//read xml file
    			XDocument data  = XDocument.Load(HttpContext.Current.Server.MapPath(Path.Combine(UrlDAL.__FilePath, UrlDAL..__FileName)));
    			//convert to list
    			urls = Xml.DeserializeCollection<Url>(data);
    		}
    		catch (Exception e)
    		{
    			//perform logging / error handling
    		}
    
    		return urls;
    
    	}
    
    	/// <summary>
    	/// Saves the list of Url entities 
    	/// </summary>
    	/// <param name="urls">The list of url objects to save</param>
    	internal static void Create(List<Url> urls)
    	{
    
    		try
    		{
    			//convert list into xml document
    			XDocument file = Xml.SerializeCollection<Url>(urls);
    			//rename the old file so you have a copy of it if saving the new file fails
    			File.Copy(Path.Combine(UrlDAL.__FilePath, UrlDAL.__FileName), Path.Combine(UrlDAL.__FilePath, UrlDAL.__FileNameTemp));
    			//saving the new file will overwrite the existing file
    			file.Save(UrlDAL.__FilePath);
    			//delete the old file
    			File.Delete(Path.Combine(UrlDAL.__FilePath, UrlDAL.__FileNameTemp));
    		}
    		catch (Exception e)
    		{
    			//perform logging / error handling
    			//you should also alert yourself of this error so you can manually restore the old file
    		}
    
    	}
    
    }
