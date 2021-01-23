    public class NewSampleModelDto
    {
       [Required]
       public string ImageUrl1 { get; set; }
       
       public NewSampleModelDto() { }
       
       public SampleModel ToModel() 
       {	
    		return new SampleModel 
    		{ 
    			ImageUrl1 = ImageUrl1
    		};
       {
    }
