    using(TransactionScope ts = new TransactionScope())
    using(OracleConnection connection = new OracleConnection(cnstring))
    {
        bool errorFound = false;
        OracleCommand cmd = new OracleCommand("INSERT INTO ZTMP_SAM_TB_ELAB_PDR " + 
                    "  VALUES (:1,:2,:3,:4,:5,:6,:7,:8,:9,:10,:11,:12,:13,:14)", connection);
        ....
        file = new System.IO.StreamReader(path+FileUpload1.FileName);
        while((line = file.ReadLine()) != null)
        {
           ....
           try
           {
               cmd.ExecuteNonQuery();
           }   
           catch(Exception ex)
           {
              Label1.Text = ex.Message;
              errorFound = true;
              break; 
           }
        }
        if(!errorFound) ts.Complete();
    }
