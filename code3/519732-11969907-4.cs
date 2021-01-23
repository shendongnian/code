    [KnownType(typeof(Student))] 
    [KnownType(typeof(Teacher))]
    [DataContract]
    public class Persons
    {
        [DataMember]
        public IEnumerable<Person>{get;set;}
    }
