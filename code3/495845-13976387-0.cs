    public partial class cfgCountry
        {
            public cfgCountry()
            {
                this.People = new HashSet<Person>();
            }
        
        	[Key]
            public int CountryID { get; set; }
            public string Name { get; set; }
            public int Ordinal { get; set; }
        
            public virtual ICollection<Person> People { get; set; }
            
            public cfgCountry ToSerializable()
            {
        	    return new cfgCountry()
        	    {
        	    CountryID = this.CountryID,
        	    Name = this.Name,
        	    Ordinal = this.Ordinal,
        	    };
            }
        }
