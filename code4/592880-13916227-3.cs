    [DataContract]
    public class Employee
    {
        public bool IsSSNSerializable = false;
        [DataMember]
        public string Name;
        [DataMember]
        public string phoneNo;
        public string SSN;
        [DataMember(Name = "SSN", EmitDefaultValue = false)]
        public string SSNSerializable
        {
            get
            {
                if (!IsSSNSerializable)
                    return null;
                return SSN;
            }
            set
            {
                SSN = value;
            }
        }
    }
