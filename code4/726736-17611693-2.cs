    public static T TryReadObject<T>(this IInputStream sessionInputStream, out T value)
    {
        try
        {
            var serializer = new DataContractSerializer(typeof(T));
            using(var stream = sessionInputStream.AsStreamForRead())
            {
                value = (T)serializer.ReadObject(stream);
                return true;
            }
        }
        catch
        {
            value = default(T);
            return false;
        }
    }
