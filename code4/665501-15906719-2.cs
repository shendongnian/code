    [MetadataType(typeof(ProjectMetadata))]
    public partial class Project
    {
        public DateTime DateSent { get; set; }
        public string Description { get; set; }
        public string TooltipText 
        { 
           get {
               return "Date: " + DateSent.ToShortDateString(); // whatever tooltip you want
           }
           set {}
        }
    }
