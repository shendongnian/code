    public class DataModel_ListOfEvents
    {
    	public DataModel_ListOfEvents(String img_thumb)
    	{
    		this.Img_Thumb = new NotifyTaskCompletion<string>(JsonCached.ImageFromCache2(img_thumb));
    	}
    	public NotifyTaskCompletion<string> Img_Thumb { get; private set; }
    }
    
    public sealed class SampleData_ListOfEvents
    {
    	private static SampleData_ListOfEvents _sampleDataSource = new SampleData_ListOfEvents();
    
    	private ObservableCollection<DataModel_ListOfEvents> _items = new ObservableCollection<DataModel_ListOfEvents>();
    	public ObservableCollection<DataModel_ListOfEvents> Items { get { return this._items; } }
    }
