            // get stuff here
            String json = GetJsonString(expression));
            List<T> result;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(List<T>));
                result = (List<T>)serializer.ReadObject(ms);
            }   
