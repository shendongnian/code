    public sealed class PartsOrder
    {
    	/// <summary>
    	/// 
    	/// </summary>	
    	[ExportOptions("Customer Name", Order=0)]
    	public string CustomerName { get; set; }
    	
    	/// <summary>
    	/// 
    	/// </summary>
    	[ExportOptions("Catalog Name", Order = 1)]
    	public string Catalog Name { get; set; }
    	
    	/// <summary>
    	/// 
    	/// </summary>
    	[ExportOptions("Unit", Order = 2)]
    	public string Unit { get; set; }
    	
    	/// <summary>
    	/// 
    	/// </summary>
    	[ExportOptions("Component", Order = 3)]
    	public string Component { get; set; }
    	
    	/// <summary>
    	/// 
    	/// </summary>
    	[ExportOptions("Delivery Point", Order = 4)]
    	public string DeliveryPoint { get; set; }
    	
    	/// <summary>
    	/// 
    	/// </summary>	
    	[ExportOptions("Order Date", Order = 5)]
    	public string OrderDate { get; set; }
    }
