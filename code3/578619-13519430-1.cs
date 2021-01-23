    public class Man : IMan<Man, Woman>
    {
    	public Woman Sweetheart { get; set; }
    }
    
    public class Woman : IWoman<Woman, Man>
    {
    	public Man Darling { get; set; }
    }
    
    public class Husband : IMan<Husband, Wife>
    {
    	public Wife Sweetheart { get; set; }
    }
    
    public class Wife : IWoman<Wife, Husband>
    {
    	public Husband Darling { get; set; }
    }
