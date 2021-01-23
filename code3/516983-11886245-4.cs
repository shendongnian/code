    [XmlRoot("Employee")]
    Public class EmployeeApiModel
    {
        [XmlElement("fname")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }
    }
