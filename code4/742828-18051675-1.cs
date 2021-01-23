    public class EditSampleModelDto
    {
       public int Id { get; set; }
       
       [Required]
       public string ImageUrl2 { get; set; }
       
       // default constructor required for mvc model binding
       public EditSampleModelDto() { }
       
       // from model ==> dto
       public EditSampleModelDto(SampleModel sampleModel) 
       { 
    		Id = sampleModel.Id;
    		ImageUrl2 = sampleModel.ImageUrl2;
       }
       
       // from dto ==> model
       public void UpdateModel(SampleModel sampleModel) 
       {	
    		sampleModel.ImageUrl2 = ImageUrl2;
       {
    }
