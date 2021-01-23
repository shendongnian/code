     int valueToRetun=-1;
     try
      {
        //insert command  (This is where the duplicate column error is thrown)
        //Select @@Identity & initialize valurToRetun
        //ValueToReturn=Identity;
      }
      catch (SqlCeException ex)
      {
       if (ex.NativeError == 25016)
            MessageBox.Show("Username already in use."); 
       else
         //whatever
      }
      finally
      {
        return valueToReturn;
      }
