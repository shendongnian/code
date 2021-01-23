    public void ProcessRequest(HttpContext context)
    	{
            string responseString = string.Empty;
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;
    
            ResourceManager rm = new ResourceManager("Resources.PM", System.Reflection.Assembly.Load("App_GlobalResources"));
            
            CultureInfo defaultCulture = new CultureInfo("en-US");
            
            ResourceSet currentRS = rm.GetResourceSet(currentCulture, true, true);
            ResourceSet defaultRS = null;
    
            if (defaultCulture != currentCulture)
            {
                defaultRS = rm.GetResourceSet(defaultCulture, true, true);
            }
            
            Dictionary<string, string> translations = new Dictionary<string, string>();
            
            if (currentRS != null)
            {
                foreach (DictionaryEntry entry in currentRS)
                {
                    try {
                        translations.Add(entry.Key.ToString(), entry.Value.ToString());
                    }
                    catch (Exception e) { }
                }
            }
            
            if (defaultRS != null)
            {
                foreach (DictionaryEntry entry in defaultRS)
                {
                    try {
                        translations.Add(entry.Key.ToString(), entry.Value.ToString());
                    }
                    catch (Exception e){}
                }
            }
    
            foreach (KeyValuePair<String, String> entry in translations)
            {
                responseString += "\"" + entry.Key.ToString() + "\": \"" + entry.Value.ToString() + "\", ";
            }
    
            responseString = "var translations = {" + responseString + " culture: \"" + currentCulture.ToString() + "\"};";
            context.Response.Write(responseString);
    
    		Compress(context);
    		//SetHeadersAndCache(absolutePath, context);
    	}
