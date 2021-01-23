    public interface IProductDescription {
    	Category ExternalCat { get; }
    	IQueryable<Options> BDetails { get; }
    	Product Product { get; }
    }
    
    public partial class PCBuild : IProductDescription {
    }
    
    public partial class Home : IProductDescription {
    }
