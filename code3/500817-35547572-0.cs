    public static T JSONDeserialize<T>(string json)
            {
                T obj = default(T);
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    obj = Activator.CreateInstance<T>();
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                    obj = (T)serializer.ReadObject(ms);
                    ms.Close();
                }`enter code here`
                return obj;
            }
