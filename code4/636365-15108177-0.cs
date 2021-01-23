     var proInfos = student.GetType().GetProperties();
              if(proInfos!=null)
                 {
                       Dictionary<string,string> dict= new Dictionary<string, string>();
                 
                 foreach (var propertyInfo in proInfos)
                 {
                    var tv = propertyInfo.GetValue(currentObj, null);
                     if(tv!=null)
                     {
                        if(dict.ContainsKey(propertyInfo.Name))
                            continue;
                        dict.Add(propertyInfo.Name, tv.ToString());
                     }
                    }
                 }
                 
