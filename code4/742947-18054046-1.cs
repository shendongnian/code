    try
    {
        string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\temp\test.xls;Extended Properties='Excel 8.0;HDR=Yes;'";
        using(OleDbConnection connectin = new  System.Data.OleDb.OleDbConnection(con));
        {
            connectin.Open();
            OleDbCommand command = new System.Data.OleDb.OleDbCommand("select * from [Sheet1$]", connectin);
            using(System.Data.OleDb.OleDbDataReader dr = command.ExecuteReader())
            {
                while (dr.Read)
                {
                    if(dr.HasRows)
                    {
                        Console.Write(dr[0].ToString() + " ");
                        Console.Write(dr[1].ToString() + " ");
                        Console.WriteLine(Convert.ToInt32(dr[2]));
                    }
                } 
            }
        }
    }
    catch(Exception ex) 
    {
        Console.WriteLine(ex.ToString()); 
    }
