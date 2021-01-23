    public enum Season 
    {
       [Display(Name = "It's autumn")]
       Autumn,
    
       [Display(Name = "It's winter")]
       Winter,
    
       [Display(Name = "It's spring")]
       Spring,
    
       [Display(Name = "It's summer")]
       Summer
    }
    public class Foo 
    {
    	public Season Season = Season.Summer;
    	
    	public void DisplayName()
    	{
    		var seasonDisplayName = Season.GetAttribute<DisplayAttribute>();
    		Console.WriteLine("Which season is it?");
    		Console.WriteLine (seasonDisplayName.Name);
    	} 
    }
