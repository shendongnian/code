    public interface IMyInterface
    {
       DateTime Created_date{ get;set; }
       // add any other common properties between the 2 models
    }
    public partial class TouchPointModel : BaseModel, IMyInterface
    {
       .......
        
       public DateTime Created_date{ get;set; }
    }
    public partial class SurveyModel : IMyInterface
    {
       .......
       public DateTime Created_date{ get;set; }
    }
