    private DataSet YourData()
    {
    cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Bill  \\dbBill.accdb");
    string query = "select     
      A.BillNo,A.BillType,A.TaxType,A.PartyName,B.Desc,B.Desc,B.HSNCode,B.Qty,B.Rate,
      (B.Qty*B.Rate) as Amount " +
     "from BillMaster A inner join BillDetail B on B.BillNo=A.BillNo";
     cn.Open();
     cmd = new OleDbCommand(query, cn);
     da = new OleDbDataAdapter(cmd);
     ds = new DataSet();
     da.Fill(ds);
     cn.Close();
     return ds;
    } 
