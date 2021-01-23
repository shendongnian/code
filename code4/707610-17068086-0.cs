    public static T ReaderField<T>(IDataReader reader, String fieldname)
    {
        try
        {
            int idx = reader.GetOrdinal(fieldname);
            if (reader.IsDBNull(idx))
            {
                return (T)default(T);
            }
            else
            {
                object o = reader.GetValue(idx);
                try
                {
                    return (T)Convert.ChangeType(o, typeof(T));
                }
                catch
                {
                    return (T)default(T);
                }
            }
        }
        catch { }
        return (T)default(T);
    }
