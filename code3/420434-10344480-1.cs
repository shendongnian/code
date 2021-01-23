    [DataContract]
    public class Person : IExtensibleDataObject
    {
        [DataMember]
        public string fullName;
        private ExtensionDataObject theData;
    
        public virtual ExtensionDataObject ExtensionData
        {
            get { return theData; }
            set { theData = value; }
        }
    }
