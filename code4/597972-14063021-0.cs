    [DataContract(IsReference = true)]
    public class Person
    {
        #region Constructor:
        public Person()
        {
            // Empty Constructor.
        }
        #endregion
        #region Data Member Properties:
		[DataMember]
        public Guid Guid { get; set; }
		
        [DataMember]
        public string First { get; set; }
        [DataMember]
        public string Last { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Site { get; set; }
        #endregion
    }
