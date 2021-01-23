    partial class MyDataContext
    {
    
        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
        {
        
            var set = this.GetChangeSet();//get a list of all pending changes
            
            foreach (var item in set.Inserts)
            {
                AddLog(item, LogType.Add);
            }
            foreach (var item in set.Updates)
            {
                AddLog(item, LogType.Edit);
            }
            foreach (var item in set.Deletes)
            {
                AddLog(item, LogType.Delete);
            }
            
            base.SubmitChanges(failureMode);//allow the DataContext to perform it's default work (including your new log changes)
        
        }
    
        public void AddLog(object item, LogType logType)
        {
        
            //some painful type testing, so feel free to refactor this as you wish
            if(item is Table1)
            {
               var log = (item as Table1).ToLog(logType);//ToLog() is an extension method (one for each type)
               this.Table1_Logs.InsertOnSubmit(log);//add the log record ready to be submitted
            }
            else if(item is Table2)
            {
               //same again
            }
            //...repeat for each table class type
        
        }
    
    }
