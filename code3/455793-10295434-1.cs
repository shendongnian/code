    public string Authentication(string studentID, string password) 
    {
        var result = students.FirstOrDefault(n => n.StudentID == studentID);
        var yourVar;       
        if (result != null)       
        {
            
            byte[] passwordHash = Hash(password, result.Salt);
            string HashedPassword = Convert.ToBase64String(passwordHash);
                        
            if (HashedPassword == result.Password)            
            {
                //return result.StudentID;
                yourVar = result.StudenID;
                // if it does return the Students ID                     
            } 
        }
        else
        //else return a message saying login failed 
        {
            yourVar = "Login Failed";
        }
        return yourVar;
    }
