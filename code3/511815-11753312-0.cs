    fileName = FileUpload1.ResolveClientUrl(FileUpload1.PostedFile.FileName);
    int count = 0;
    DataClassesDataContext conLinq = new DataClassesDataContext("Data Source=server name;Initial Catalog=Database Name;Integrated Security=true");
    try
    {
       DataTable dtExcel = new DataTable();
       string SourceConstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties= 'Excel 8.0;HDR=Yes;IMEX=1'";
       OleDbConnection con = new OleDbConnection(SourceConstr);
       string query = "Select * from [Sheet1$]";
       OleDbDataAdapter data = new OleDbDataAdapter(query, con);
       data.Fill(dtExcel);
       for (int i = 0; i < dtExcel.Rows.Count; i++)
       {
          try
          {
             count += conLinq.ExecuteCommand("insert into table name values(" + dtExcel.Rows[i][0] + "," + dtExcel.Rows[i][1] + ",'" + dtExcel.Rows[i][2] + "',"+dtExcel.Rows[i][3]+")");
          }
          catch (Exception ex)
          {
             continue;
          }
       }
       if (count == dtExcel.Rows.Count)
       {
          <--Success Message-->
       }
       else
       {
          <--Failure Message-->
       }
    }
    catch (Exception ex)
    {
       throw ex;
    }
    finally
    {
    }
