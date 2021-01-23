    public class PersonMap : ClassMap<Person>
    {
        public PersonMap ()
        {           
            Id (x => x.PersonId).GeneratedBy.Sequence("person_person_id_seq");
            
            Map (x => x.Lastname).Not.Nullable();
            Map (x => x.Firstname).Not.Nullable();
            // No Inverse
            HasMany(x => x.PhoneNumbers).Cascade.All ();
        }
    }
    
    public class PhoneNumberMap : ClassMap<PhoneNumber>     
    {
        public PhoneNumberMap ()
        {
            References(x => x.Person);          
            
            Id (x => x.PhoneNumberId).GeneratedBy.Sequence("phone_number_phone_number_id_seq");
            Map (x => x.ThePhoneNumber).Not.Nullable();                       
        }
    }
