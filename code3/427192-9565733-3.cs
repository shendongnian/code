    public interface IProductDescription {
    	Category ExternalCat { get; }
    	IQueryable<Option> BDetails { get; }
    }
    
    public partial class PCBuild : IProductDescription {
    }
    
    public partial class Home : IProductDescription {
    }
