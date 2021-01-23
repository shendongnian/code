    // Base class from which all Item objects derive
    public abstract class Item
    {
    	public int ItemId { get; set; }
    }
    
    public class WeaponItem : Item
    {
    	// Add properties specific to WeaponItem here.
    }
    
    public class ArmorItem : Item
    {
    	// Add properties specific to ArmorItem here.
    }
