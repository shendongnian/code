      private List<Url> AddURLToFile(Urls urls,Url url) 
            {
                string filePath = @"D:\test\file.json";
                urls.UrlList.Add(url);
    
                //if (!System.IO.File.Exists(filePath))
                //    using (System.IO.File.Delete(filePath));
    
                System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(urls.UrlList));
    
                //using (StreamWriter sw = (System.IO.File.Exists(filePath)) ? System.IO.File.AppendText(filePath) : System.IO.File.CreateText(filePath))
                //{
                //    sw.WriteLine(JsonConvert.SerializeObject(urls.UrlList));
                //}
                return urls.UrlList;
            }
            private List<Url> ReadURLToFile()
            {
                //  string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"App_Data\file.json");
                string filePath =  @"D:\test\file.json";
    
                List<Url> result = new List<Url>(); ;
                if (!System.IO.File.Exists(filePath))
                    using (System.IO.File.CreateText(filePath)) ;
                  
                  
             
                 using (StreamReader file = new StreamReader(filePath))
                {
                    result = JsonConvert.DeserializeObject<List<Url>>(file.ReadToEnd());
                    file.Close();
                }
                if (result == null)
                    result = new List<Url>();
    
                return result;
    
            }
