    public interface IRecordedItems
    {
        ObservableCollection<RecordedItem> Load( string name );
        void Save();
    }
    
    
    public interface IRecordedItemsProcessor<T> : IRecordedItems
    {
        RecordedItem Parse( T itemToParse );
    }
    
    public class MyClass : IRecordedItems
    {
        #region Implementation of IRecordedItems
    
        public ObservableCollection<RecordedItem> Load( string name )
        {
            throw new NotImplementedException();
        }
    
        public void Save()
        {
            throw new NotImplementedException();
        }
    
        #endregion
    }
