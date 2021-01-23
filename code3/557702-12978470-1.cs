    public class Person
    {
    	private string _email = string.empty;
    	private string _telephone = string.empty;
    	private Address _address = new Address();
    	
    	public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { 
        	get { return _email }
        	set { AddOrChangeEmail(value); }
        }
        public string Telephone { 
        	get { return _telephone;}
        	set { AddOrChangeTelephone(value); }
         }
        public Address Address { 
        	get { return _address;  }
    		set { AddOrChangeAddress(value); }
    	}
    
        public Person(string firstName, string lastName)
        {
            //do null-checks
            FirstName = firstName;
            LastName = lastName;
        }
    
        private void AddOrChangeEmail(string email)
        {
            //Check if e-mail is a valid e-mail here
            _email = email;
        }
    
        private void AddOrChangeTelephone(string telephone)
        {
            //Check if thelephone has correct format and valid symbols
            _telephone = telephone;
        }
    
        private void AddOrChangeAddress(Address address)
        {
            _address = address;
        }
    }
