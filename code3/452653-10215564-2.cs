    public class TrayIconForm : Form
    {
      private SqlConnection connection = null;
      
      private void Form_Load(object sender, EventArgs args)
      {
        TaskScheduler ui = TaskScheduler.FromCurrentSynchronizationContext();
    
        Task.Factory.StartNew(() =>
          {
            var sql = new SqlConnection();
            sql.ConnectionString = "your connection string";
            sql.Open();
            return sql;
          }).ContinueWith((task =>
          {
            connection = task.Result;
            // You can access other UI elements here as needed.
          }), ui);
      }
    }
