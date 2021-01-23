    [KnownType(typeof(Student))] 
    [KnownType(typeof(Teacher))]
    [Serializable]
    public class Persons
    {
        public IEnumerable<Person>{get;set;}
    }
