    public class DataTableDictionary<T> where T: DataTableDictionary
    {
        private static DataView cachedView;  
    }
    public class ColourDictionary : DataTableDictionary<ColourDictionary>
    {
    }
    public class XyDictionary : DataTableDictionary<XyDictionary>
    {
    }
