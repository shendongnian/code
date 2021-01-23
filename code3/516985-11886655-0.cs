    [DataContract(Name = "Employee")]
    public class EmployeeApiModel
    {
        [DataMember(Name = "Name2")]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
