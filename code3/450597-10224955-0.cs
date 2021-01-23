    public class Song
    {
    	...
    	public virtual ICollection<Album> Albums { get; set; }
    }
    
    public class Album
    {
    	...
    	public virtual ICollection<Song> Songs { get; set; }
    }
