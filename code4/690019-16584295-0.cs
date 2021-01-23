    OracleTransaction myTrans = null;   
    OracleCommand cmd = new OracleCommand("INSERT INTO ZTMP_SAM_TB_ELAB_PDR " + 
    "  VALUES (:1,:2,:3,:4,:5,:6,:7,:8,:9,:10,:11,:12,:13,:14)", connection);
    connection.open();//if not done already.
    myTrans = connection.BeginTransaction();
    cmd.Transaction = myTrans; 
 
    file = new System.IO.StreamReader(path+FileUpload1.FileName);
    while((line = file.ReadLine()) != null)
    {
       string[] split = line.Split(',');
       cmd.Parameters.Add("1", OracleType.VarChar, 64).Value = split[0];
       cmd.Parameters.Add("2", OracleType.VarChar, 64).Value = "";
       cmd.Parameters.Add("3", OracleType.VarChar, 64).Value = "";
       cmd.Parameters.Add("4", OracleType.Number).Value = Convert.ToInt32(split[1]);
       cmd.Parameters.Add("5", OracleType.VarChar, 64).Value = split[6];
       cmd.Parameters.Add("6", OracleType.VarChar, 64).Value = split[7];
       cmd.Parameters.Add("7", OracleType.Number).Value = Convert.ToInt32(split[8]);
       cmd.Parameters.Add("8", OracleType.Number).Value = Convert.ToInt32(split[9]);
       cmd.Parameters.Add("9", OracleType.VarChar, 80).Value = split[2];
       cmd.Parameters.Add("10", OracleType.VarChar, 80).Value = split[3];
       cmd.Parameters.Add("11", OracleType.Number).Value = Convert.ToInt32(split[4]);
       cmd.Parameters.Add("12", OracleType.Number).Value = Convert.ToInt32(split[5]);
       DateTime date1,date2;
       DateTime.TryParseExact(split[10], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date1);
       DateTime.TryParseExact(split[11], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date2);
       cmd.Parameters.Add("13", OracleType.DateTime).Value = date1;
       cmd.Parameters.Add("14", OracleType.DateTime).Value = date2;
      try
        {
           cmd.ExecuteNonQuery();          
        }   
       catch(Exception ex)
        {
          myTrans.Rollback(); 
          Label1.Text = ex.Message;   
          break; 
        }
      
    }
    myTrans.Commit(); 
    connection.close();
