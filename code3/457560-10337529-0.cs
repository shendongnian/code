    public sealed class MyDataSet{
    
    public static DataSet ds= new DataSet();
    
    private static object _lock =new object();
    
    public static UpdateRow(key,data)
    {
      lock(_lock){
        DataRow dr=ds.Tables[0].Rows.Find(key);
        dr.AcceptChanges();
        dr.BeginEdit();
        dr["col"]=data;
        dr.EndEdit();
      }
    }
    }
