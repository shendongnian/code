    public class RecordedItem {}
    
    public interface IRecordedItemsProcessor
    {
        ObservableCollection<RecordedItem> Load( string name );
    
        void Save();
    
        RecordedItem Parse<T>( T itemToParse );
    }
    
    public class MyClass
    {
        private readonly IRecordedItemsProcessor _processor;
    
        public MyClass( IRecordedItemsProcessor processor )
        {
            _processor = processor;
    
            processor.Parse<string>( "foo" );
            processor.Parse<int>( 10 );
            processor.Parse<RecordedItem>( new RecordedItem() );
        }
    }
