    using NHibernate;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;
    
    public class PersonMapping : ClassMapping<Person>
    {
        public PersonMapping()
        {
            ...
    
            ManyToOne(x => x.Address, map =>
                                       {
                                           map.Column("AddressId");                                           
                                           map.Class(typeof(Address));
                                       }
                );
                
           ...
        }
    }
