    public interface Relationship<TMan, TWoman> 
    	where TMan : Man 
    	where TWoman : Woman
    {
    	TMan Darling { get; }
    	TWoman Sweetheart { get; }
    }
    
    public class Marriage : Relationship<Husband, Wife>
    {
    }
