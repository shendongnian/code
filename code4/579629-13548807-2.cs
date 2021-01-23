     try
      {
        //insert command  (This is where the duplicate column error is thrown)
        //Select @@Identity & Return it       
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
        return -1;
      }
