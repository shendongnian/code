    class Student
    {
        // your code
        // ...
        public bool IsValid()
        {
            bool isValid = true;
            
            if(string.IsNullOrWhiteSpace(FirstName))
            {
               isValid = false;
            }
            else if(string.IsNullOrWhiteSpace(LastName))
            {
               isValid = false;
            }
            // ... rest of your validation here
    
            return isValid;
        }
    }
