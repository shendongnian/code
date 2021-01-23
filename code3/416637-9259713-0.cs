            public static Stream GetStream(string resourceName, Assembly containingAssembly)
            {
                string fullResourceName = containingAssembly.GetName().Name + "." + resourceName;
                Stream result = containingAssembly.GetManifestResourceStream(fullResourceName);
                if (result == null)
                {
                    // throw not found exception
                }
    
                return result;
            }
    
    
            public static string GetString(string resourceName, Assembly containingAssembly)
            {
                string result = String.Empty;
                Stream sourceStream = GetStream(resourceName, containingAssembly);
    
                if (sourceStream != null)
                {
                    using (StreamReader streamReader = new StreamReader(sourceStream))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
                if (resourceName != null)
                {
                    return result;
                } 
            }
