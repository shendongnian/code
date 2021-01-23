       public static T DeepCopy<T>(this T obj)
            {
                T result;
                var serializer = new DataContractSerializer(typeof(T));
                using (var ms = new MemoryStream())
                {
    
                    serializer.WriteObject(ms, obj);
                    ms.Position = 0;
    
                    result = (T)serializer.ReadObject(ms);
                    ms.Close();
                }
    
                return result;
            }
