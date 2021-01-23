    public class YourItem
    {
    	public string Code { get; set; }
    	public string Name { get; set; }
    	public string MRP { get; set; }
    	public int OrdersCount { get; set; }
    	public int PendingCount { get; set; }			
    }
    
    void YourHandler()
    {
    	listView1.Items.Clear();
    	listView1.Columns.Clear();
    	
    	var items = new[] 
    	{
    		new YourItem { Code = "Code1", Name = "Name1", MRP = "MRP1", OrdersCount = 1, PendingCount = 1 },
    		new YourItem { Code = "Code2", Name = "Name2", MRP = "MRP2", OrdersCount = 2, PendingCount = 2 },
    		new YourItem { Code = "Code3", Name = "Name3", MRP = "MRP3", OrdersCount = 3, PendingCount = 3 },
    	};
    	   	
    	listView1.Columns.Add("CODE", -2,HorizontalAlignment.Left);
    	listView1.Columns.Add("NAME", -2,HorizontalAlignment.Left);
    	listView1.Columns.Add("MRP", -2,HorizontalAlignment.Left);
    	listView1.Columns.Add("ORDERS", -2,HorizontalAlignment.Left);
    	listView1.Columns.Add("PENDING", -2,HorizontalAlignment.Left);
    	  	
    	foreach (var item in items)
    	{
    		// Fill item
    		ListViewItem item = new ListViewItem(item.Code);
    		item.SubItems.Add(item.Name);
    		item.SubItems.Add(item.MRP);
    		item.SubItems.Add(item.OrdersCount);
    		item.SubItems.Add(item.PendingCount);
    	
    		// Add to the ListView
    		listView1.Items.Add(item);	
    	}
    }
