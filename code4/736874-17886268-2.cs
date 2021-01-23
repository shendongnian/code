    public class Tweet
    {
    	public String imgSrc { get; set; }
    	public String user { get; set; }
    	public String tweet { get; set; }
    
    	public Tweet(){}
    
    	public Tweet(String user, String tweet, String img)
    	{
    		this.imgSrc = img;
    		this.user = user;
    		this.tweet = tweet;
    	}
    }
