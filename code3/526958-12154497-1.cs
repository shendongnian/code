    try 
    {
      // create objects, set properties ...
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
