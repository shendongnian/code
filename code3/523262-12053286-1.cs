                [WebMethod]
                public static string LoadStrings(string jsonString)
                {
                    try
                    {
                        JavaScriptSerializer s = new JavaScriptSerializer();
        
                        string[] stringArray = s.Deserialize<string[]>(jsonString);
                    }
                    ...
                }
