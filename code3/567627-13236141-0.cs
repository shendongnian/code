    public byte[] Serialize(object myObject)
    {
        using (var ms = new MemoryStream())
        {
            Type type = myObject.GetType();
            var id = System.Text.ASCIIEncoding.ASCII.GetBytes(type.FullName + '|');
            ms.Write(id, 0, id.Length);
            Serializer.Serialize(ms, myObject);
            var bytes = ms.ToArray();
            return bytes;
        }
    }
    public object Deserialize(byte[] serializedData)
    {
        StringBuilder sb = new StringBuilder();
        using (var ms = new MemoryStream(serializedData))
        {
            while (true)
            {
                var currentChar = (char)ms.ReadByte();
                if (currentChar == '|')
                {
                    break;
                }
                sb.Append(currentChar);
            }
            string typeName = sb.ToString();
            // assuming that the calling assembly contains the desired type.
            // You can include aditional assembly information if necessary
            Type deserializationType = Assembly.GetCallingAssembly().GetType(typeName);
            MethodInfo mi = typeof(Serializer).GetMethod("Deserialize");
            MethodInfo genericMethod = mi.MakeGenericMethod(new[] { deserializationType });
            return genericMethod.Invoke(null, new[] { ms });
        }
    }
