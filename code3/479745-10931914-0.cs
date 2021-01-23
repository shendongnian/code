    Task myTask = Task.Factory.StartNew(
         new Action(() =>
         {
             DataSet ds;
             DataTable dt = new DataTable();    
             //GetMyDataSet() returns DataSet
             ds = GetMyDataSet();
             dt = ds.Tables["MyTableName"];
             // use Invoke/BeginInvoke to update UI
          }));
