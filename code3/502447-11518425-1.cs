    string cnStr=@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\myFolder\myExcel2007file.xlsx;Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
    DataTable dt=new DataTable();
    string sql="Select * From [Sheet1$]";
    using(OleDbConnection cn=new OleDbConnection(cnstr))
    {
      using(OleDbDataAdapter adapter=new OleDbDataAdapter(sql,cn))
       {
         adapter.Fill(dt);
       }
    }
