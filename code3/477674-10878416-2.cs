    //remove the "Bind Exclude"
    public class Collection
    {
        public int Id { get; set; }//make it int, it will be taken as the primary key
        public string collectionName { get; set; }
    
        public virtual IList<Project> Projects { get; set; }//make it virtual, lazy loading inside
    }
