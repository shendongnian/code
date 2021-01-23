    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        { get; set; }
    }
     /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Results
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "names")]
        public List<Result> Names
        { get; set; }
    }
    
