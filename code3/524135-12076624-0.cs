	public interface IRecordedItemsProcessor 
	{
	}
	
	public interface IRecordedItemsProcessor<T> : IRecordedItemsProcessor
	{
		ObservableCollection<RecordedItem> Load(string name);
		void Save();
		RecordedItem Parse(T itemToParse);
	}
