    public class RunTableStatisticsController : AsyncController 
    {
        public void RunTableStatisticsAsync()
        {
            AsyncManager.OutstandingOperations.Increment(2);
    
            // Create tasks that populate RunTableStatisticsModels DataTables
    
            Task.Factory.StartNew(() =>
            {
                AsyncManager.Parameters["dt1"] = DAL.GetDataTable1();
                AsyncManager.OutstandingOperations.Decrement();
            });
    
            Task.Factory.StartNew(() =>
            {
                AsyncManager.Parameters["dt2"] = DAL.GetDataTable2();
                AsyncManager.OutstandingOperations.Decrement();
            });
        }
    
        public ViewResult RunTableStatisticsComplete(DataTable dt1, DataTable dt2)
        {
            var model = new RunTableStatisticsModel
            {
                DtTable1 = dt1,
                DtTable2 = dt2,
            };
            return View(model);
        }
    }
