     public AddressBook()
        {
            name2Addresses = new Dictionary<string,IEnumerable<string>>(); //changed ere
            List<string> addresses = new List<string>(); 
            name2Addresses.Add("Anne Best", addresses);
            addresses.Add("Home address");
            addresses.Add("Work address");
        }
