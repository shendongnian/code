        private string firstName, lastName;
    
        public string Name
        {
            
            get { return firstName + " " + lastName; }
            private set;
        }
        public bool TryParseName(string name)
        {
            bool isValid = true;
            string[] nameParts = name.split(' ');
            if(nameParts.Length == 2) 
            {
                 firstName = nameParts[0];
                 lastName = nameParts[1];
            }
            else
            {
                 isValid = false;
            }
            return isValid;
        }
    }
