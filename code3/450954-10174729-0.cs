    [MetadataType(typeof(MyClass_Validation))]     
    public partial class MyClass
    {} 
            
    public class MyClass_Validation     
    {     
       [DisplayFormat(...)] 
       public DateTime StartDate { get; set; } 
    }
