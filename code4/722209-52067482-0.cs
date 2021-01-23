    public static T GetDataType<T>( this SqlDataReader r, string name, object def = null )
    {
         var col = r.GetOrdinal(name);
         return r.IsDBNull(col) ? (T)def : (T)r[name];
    }
