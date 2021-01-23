     public static Dictionary<string,string> GetDocumentMetadata(string fileName)
            {
                var properties = new Dictionary<string,string>();
                var arrHeaders = new List<string>();
    
                var shell = new Shell();
                var objFolder = shell.NameSpace(HttpContext.Current.Server.MapPath("~/RawFiles"));
                var file = objFolder.ParseName(fileName);
    
                for (var i = 0; i < short.MaxValue; i++)
                {
                    var header = objFolder.GetDetailsOf(null, i);
                    if (String.IsNullOrEmpty(header))
                        break;
                    arrHeaders.Add(header);
                }
    
                for (var i = 0; i < arrHeaders.Count; i++)
                {
                    var value = objFolder.GetDetailsOf(file, i);
                    if (!String.IsNullOrEmpty(value))
                    {
                        properties.Add(arrHeaders[i], value);
                    }
                }
               
                return properties;
            } 
