    public class Person
        {
            public virtual int Id { get; set; }
    
            public virtual string Name { get; set; }
    
            public virtual IList<Address> Addresses { get; set; }
    
        }
    
    public class Address
        {
            public virtual int Id { get; set; }
    
            public virtual int PersonId { get; set; }
    
            public virtual string Street { get; set; }  
        }
    
    public class PersonOverrides : IAutoMappingOverride<Person>
    	{
    		public void Override(AutoMapping<Person> mapping)
    		{
    			mapping.Id(x => x.Id);
    			mapping.HasMany(x => x.Addresses).KeyColumn("PersonId").Cascade.All();            
    		}
    	}
