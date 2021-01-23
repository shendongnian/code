            private T DeepCopy<T>(T obj)
        {
            object result = null;
            if (obj == null)
            {
                return (T)result;
            }
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                result = (T)formatter.Deserialize(ms);
                ms.Close();
            }
            return (T)result;
        }
