    [DataContract]
    public class EmployeeSearchParams
    {
        [DataMember]
        public Employee Manager {get; set;}
        [DataMember]
        public bool ManagerSupplied {get; set;}
    }
