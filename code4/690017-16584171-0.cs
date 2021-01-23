    // ...
    file = new System.IO.StreamReader(path+FileUpload1.FileName);
    try
    {
      while((line = file.ReadLine()) != null)
      {
        // Parameters...
        cmd.ExecuteNonQuery();
      }
      myTrans.Commit(); 	
    }					
    catch(Exception ex)
    {
      myTrans.Rollback(); 
      // ...
    }
