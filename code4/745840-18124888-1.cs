    public class TableColumns
    {
       public int TableColumn1 { get;set; }
       public string TableColumn2 { get;set; }
       public float TableColumn3 { get;set; }
       //additional columns if any
    }
    public class PivotColumns
    {
       public string PivotColumn1 { get;set; }
	   public int PivotColumn2 { get;set; }
	   public float PivotColumn3 { get;set; }       
	   //additional columns if any
    }
    public class MyClass : TableColumns, PivotColumns{ }
    
    public static class ConversionHelper
    {
       public static List<MyClass> ConvertDataRowToMyClass(DataTable dt)
       {
               // some implementation
               List<MyClass> ltMyClass = (from dr in dataTable.AsEnumerable()
                                             select new MyClass
                                             {
                                                 TableColumn1 = dr["TableColumn1"] == DBNull.Value || dr["TableColumn1"] == null ? default(int) : dr.Field<int>("TableColumn1"),
                                                 PivotColumn2 = dr.Field<int>("PivotColumn2"),
                                                 TableColumn2 = dr.Field<string>("TableColumn2")
                                             }).ToList<MyClass>();
       }
       public static DataTable ConvertMyClassToDataRow(List<MyClass> lstMyClass)
       {
               // some implementation
               PropertyDescriptorCollection properties = 
               TypeDescriptor.GetProperties(typeof(MyClass));
               DataTable table = new DataTable();
               foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
               foreach (T item in data)
               {
                   DataRow row = table.NewRow();
                   foreach (PropertyDescriptor prop in properties)
                           row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                   table.Rows.Add(row);
               }
               return table;
       }
    }
