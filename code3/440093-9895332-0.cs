    public abstract class PersonBaseMap<TPerson> : ClassMap<TPerson> where TPerson : Person
    {
        public PersonBaseMap()
        {
           Map(p => p.Name);
           Map(p => p.Age);
           Map(p => p.Address);
        }
    }
    
    public class PersonMap : PersonBaseMap<Person>
    {
    }
    
    public class PersonExtMap : PersonBaseMap<PersonExt>
    {
        public PersonExtMap()
        {
           Map(p => p.NumOfChildren);
           Map(p => p.FamilyStatus);
        }
    }
