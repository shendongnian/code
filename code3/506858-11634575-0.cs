    [DataContract(Name = "Customer", Namespace = "http://www.contoso.com")]
    class Person : IExtensibleDataObject
    {
        [DataMember()]
        public string FirstName;
        [DataMember]
        public string LastName;
        [DataMember()]
        public int ID;
    
        public Person(string newfName, string newLName, int newID)
        {
            FirstName = newfName;
            LastName = newLName;
            ID = newID;
        }
    
        private ExtensionDataObject extensionData_Value;    
        public ExtensionDataObject ExtensionData
        {
            get { return extensionData_Value; }
            set { extensionData_Value = value; }
        }
    }
