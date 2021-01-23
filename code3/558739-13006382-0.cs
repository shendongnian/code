    [DataContract]
    public class StudentX
    {       [DataMember]
            public string studentId;
            [DataMember]
            public string studentName;
            [DataMember]
            public string studentBirthday;
           
            public Studentx(string Id, string Name, string Birthday)
            {
                // TODO: Complete member initialization
                studentId= Id;
                studentName = Name;
                studentBirthday= Birthday;               
            }
     }
