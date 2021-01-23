    public interface IDataListEntry { 
        Type TheTypeOfT { get; }
    }
    
    public class DataListEntry<T> : IDataListEntry where ... {
        Type TheTypeOfT { get { return typeof(T); } }
    }
