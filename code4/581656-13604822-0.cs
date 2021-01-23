    public class Model
    {
    	public int ModelProperty1 { get; set; }
    	public int ModelProperty2 { get; set; }
    	public int ModelPropertyStatus { get; set; }
    }
    
    void Main()
    {
    	ObservableCollection<Model> _listOfModel = new ObservableCollection<Model>();
    	_listOfModel.CollectionChanged += (s, o) =>
    	{
    		foreach (var m in o.NewItems)
    			((Model)m).ModelPropertyStatus = 1;
    	};
    	
    	var model = new Model();
    	
    	Console.WriteLine("Before add: " + model.ModelPropertyStatus.ToString());
    	
    	_listOfModel.Add(model);
    	
    	Console.WriteLine("After add: " + model.ModelPropertyStatus.ToString());
    }
