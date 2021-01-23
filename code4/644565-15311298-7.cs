    /// <summary>
    /// Deserializes the XML data contained by the specified System.String
    /// </summary>
    /// <typeparam name="T">The type of System.Object to be deserialized</typeparam>
    /// <param name="s">The System.String containing XML data</param>
    /// <returns>The System.Object being deserialized.</returns>
    public static T XmlDeserialize<T>(this string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return default(T);
        }
    
        var locker = new object();
        var stringReader = new StringReader(s);
        var reader = new XmlTextReader(stringReader);
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            lock (locker)
            {
                var item = (T)xmlSerializer.Deserialize(reader);
                reader.Close();
                return item;
            }
        }
        catch
        {
            return default(T);
        }
        finally
        {
            reader.Close();
        }
    }
