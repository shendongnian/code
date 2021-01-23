    public class SearchModel
    {
    	public List<TagDetails> Tags { get; set; }
    	
    	public SearchModel()
    	{
    		Tags = new List<TagDetails>();
    	}
    	
    	public SearchModel(List<TagDetails> tagDetails)
    	{
    		Tags = tagDetails;
    	}
    }
