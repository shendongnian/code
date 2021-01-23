    public static T DeserializeXml<T>(this string xml) where T : class, new()
    {
        //...
        catch
        {
            x = new T();
        }
        //...
        return x as T;       
    }
