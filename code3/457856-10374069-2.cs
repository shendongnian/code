    var sess = Mapper.GetSessionFactory().OpenSession();
    
    var tx = sess.BeginTransaction();
    
    var jl = new Person { Firstname = "John", Lastname = "Lennon", PhoneNumbers = new List<PhoneNumber>() };
    var pm = new Person { Firstname = "Paul", Lastname = "McCartney", PhoneNumbers = new List<PhoneNumber>() };
 
    // Notice that we didn't indicate Parent key(e.g. Person = jl) for ThePhoneNumber 9.       
    // If we don't have Inverse, it's up to the parent entity to own the child entities
    jl.PhoneNumbers.Add(new PhoneNumber { ThePhoneNumber = "9" });
    jl.PhoneNumbers.Add(new PhoneNumber { ThePhoneNumber = "8" });
    jl.PhoneNumbers.Add(new PhoneNumber { ThePhoneNumber = "6" });
    
    jl.PhoneNumbers.Add(new PhoneNumber { Person = pm, ThePhoneNumber = "1" });
            
            
    sess.Save (pm);
    sess.Save (jl);                     
    
    
    tx.Commit();            
