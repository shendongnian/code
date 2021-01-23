    public class PartWrapper{
    	public Part Part{ get; set;}
    	public Order Order{ get; set;}
    	public bool ShowOrder{ get; set;}
    
    	public PartWrapper(Part part, Order order, bool showOrder){
    		this.Part = part;
    		this.Order = order;
    		this.ShowOrder = showOrder;
    	}
    }
    
    var items = this.orders.SelectMany(o => o.Parts.Select(p => new PartWrapper(p, o, false)) ).ToList();
    foreach(var item in items.GroupBy(i => i.Order).Select(g => g.First()))
    	item.ShowOrder = true;
