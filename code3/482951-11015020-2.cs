    private void ReadFromDB()
    {
        using(OleDbConnection myCon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\UserName\\Desktop\\MyClubAdministration\\MyClubAdministrationDB.accdb;Persist Security Info=False;"))
        {
             myCon.Open();             
             OleDbCommand myQuery = new OleDbCommand("select * from Lid, Lidgeld, Lidmaatschap", myCon);
             OleDbDataReader myReader = myQuery.ExecuteReader();
             if(myReader.HasRows)
             {
                  myReader.Read();
                  textBox1.Text = myReader.GetInt32(0).ToString();
             }
        }
    }
