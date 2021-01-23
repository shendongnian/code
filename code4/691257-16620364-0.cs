    class Details
    {
        private string firstName, lastName;
    
        public string Name
        {
            // name
            get { return firstName + " " + lastName; }
            set 
            { 
                string name = value;
                string[] nameArray = name.Split(' ');
                if(nameArray.Length == 2) 
                {
                    firstName = nameArray[0];
                    lastName = nameArray[1];
                } 
                else
                {
                    firstName = nameArray[0]; 
                    lastName = string.Empty;
                }
            }
        }
        public bool IsValid()
        {
             return !string.IsNullOrEmpty(lastName);
        }
    }
