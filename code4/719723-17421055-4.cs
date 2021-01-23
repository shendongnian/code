    SqlCommand myCommand = new SqlCommand("Select * from table",  myConnection);
    
    SqlDataReader myReader = myCommand.ExecuteReader();
    while (myReader.Read())
    {
         //Col1-7 are lists
         Col1.Add(myReader["Column1"].ToString());
         Col2.Add(myReader["Column2"].ToString());
         Col3.Add(myReader["Column3"].ToString());
         Col4.Add(myReader["Column4"].ToString());
         Col5.Add(myReader["Column5"].ToString());
         Col6.Add(myReader["Column6"].ToString());
         Col7.Add(myReader["Column7"].ToString());
    }
