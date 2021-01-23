    //remove any "collection_Id" property
    public class Project
    {
        public int Id { get; set; }//make it it, rename it, it will be taken as PK
        public string projectName { get; set; }
        public string projectCity { get; set; }
    
        public virtual Collection Collection { get; set; }
    }
