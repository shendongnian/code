    partial class tbProductsTableAdapter
    {
        internal DataTable fillProductsDataTable(SqlCommand myCommand)
        {
            DataTable result = new DataTable();
    
               try
               {
                   this.Connection.Open();
                   myCommand.Connection = this.Connection;
                   this.Adapter.SelectCommand = myCommand;
    
                   this.Adapter.fill(result);
    
                   this.Connection.Close();
               }
               catch (Exception e)
               {
               }
    
            return result;
        }
    }
