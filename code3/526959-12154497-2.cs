    try 
    {
      // create objects, set properties ...
      PersonalInfo myRecipient = new PersonalInfo();
      myRecipient.FirstName = id_firstName.ToString(); // CHECK if value is valid (correct max length, ..)
      // and so on ..
      // set reference from Entity Department to Recipient
      myDepartment.PersonalInfo = myRecipient;
      myDB.AddToPersonalInfoes(myRecipient);
      myDB.AddToDepartments(myDepartment);
      myDB.SaveChanges();
    } 
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      if (ex.InnerException!=null)
        Debug.WriteLine(ex.InnerException.Message);
    }
