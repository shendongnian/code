    public static string JSONSerialize<T>(T obj)
            {
                string retVal = String.Empty;
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                    serializer.WriteObject(ms, obj);
                    var byteArray = ms.ToArray();
                    retVal = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                }
                return retVal;
            }
