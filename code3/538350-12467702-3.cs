    protected Page_Load(object sender, EventArgs e)
    {
    	var list = new List<IWatchamacallit>();
    	list.Add(new Store { Property1 = "Store1", Property2 = "StoreInfo"});
    	list.Add(new Store { Property1 = "Store2", Property2 = "StoreInfo" });
    	list.Add(new Deal { Property1 = "Deal1", Property2 = "DealInfo" });
    	list.Add(new Deal { Property1 = "Deal2", Property2 = "DealInfo" });
    	
    	myListView.DataSource = list;
    	myListView.DataBind();
    	
    	/*	from here just set your page controls to call the properties
    		for instance:
    			<asp:Label Text='<%# Eval("Property1") %>' />
    			<asp:Label text='<%# Eval("Property2") %>' />	
    	*/
    }
    
    public interface IWatchamacallit
    {
    	string Property1 { get; set; }
    	string Property2 { get; set; }
    }
    
    public class Store : IWatchamacallit
    {
    	public string Property1 { get; set; }
    	public string Property2 { get; set; }
    }
    
    public class Deal : IWatchamacallit
    {
    	public string Property1 { get; set; }
    	public string Property2 { get; set; }
    }
