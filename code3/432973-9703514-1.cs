    public class DataTableDictionary<T> where T: DataTableDictionary<T>
    {
        private static DataView cachedView;  
    }
    public class ColourDictionary : DataTableDictionary<ColourDictionary>
    {
    }
    public class XyDictionary : DataTableDictionary<XyDictionary>
    {
    }
