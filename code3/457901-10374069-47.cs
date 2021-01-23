    public static void Main (string[] args)
    {
        var sess = Mapper.GetSessionFactory().OpenSession();
        
        var tx = sess.BeginTransaction();
        
        var jl = new Person { Firstname = "John", Lastname = "Lennon", PhoneNumbers = new List<PhoneNumber>() };
        var pm = new Person { Firstname = "Paul", Lastname = "McCartney", PhoneNumbers = new List<PhoneNumber>() };
        
        jl.AddToPhoneNumbers(new PhoneNumber { ThePhoneNumber = "9" });
        jl.AddToPhoneNumbers(new PhoneNumber { ThePhoneNumber = "8" });
        jl.AddToPhoneNumbers(new PhoneNumber { ThePhoneNumber = "6" });
        
        pm.AddToPhoneNumbers(new PhoneNumber { ThePhoneNumber = "1" });
                
                
        sess.Save (pm);
        sess.Save (jl);                     
        
        
        tx.Commit();            
    }
