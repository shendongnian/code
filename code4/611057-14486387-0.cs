    public class Model: IHasId<Guid>
    {
        [PrimaryKey]
        [Index(Unique = true)]
        public Guid Id { get; set; }
        // Other Fields...
        /// <summary>  
        /// A store of extra fields not required by the data model.  
        /// </summary>  
        public Dictionary<string, object> CustomFields { get; set; }  
    }
