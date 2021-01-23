    public class Person
    {
    	public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { 
        	get; 
        	set { AddOrChangeEmail(value); }
        }
        public string Telephone { 
        	get;
        	set { AddOrChangeTelephone(value); }
         }
        public Address Address { 
        	get; 
    		set { AddOrChangeAddress(value); }
    	}
    
        public Person(string firstName, string lastName)
        {
            //do null-checks
            FirstName = firstName;
            LastName = lastName;
            Address = new Address();
        }
    
        private void AddOrChangeEmail(string email)
        {
            //Check if e-mail is a valid e-mail here
            Email = email;
        }
    
        private void AddOrChangeTelephone(string telephone)
        {
            //Check if thelephone has correct format and valid symbols
            Telephone = telephone;
        }
    
        private void AddOrChangeAddress(Address address)
        {
            Address = address;
        }
    }
