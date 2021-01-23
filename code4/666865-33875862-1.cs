    namespace MyProjectName.Models
    {
    
        public class MyModelMeta
        {
            
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]  // format used by Html.EditorFor
            public DateTime StartDate;
            [Display(Name = "User ID")] // abbreviation shown in Html.DisplayNameFor
            public string SomeReallyLongUserIDColumn;
    
        }
    
        [MetadataType(typeof(MyModelMeta))]
        public partial class MyModel
        {
    
        }
    }
