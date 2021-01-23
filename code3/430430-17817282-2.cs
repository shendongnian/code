     var filterDate = dtRemoveLogs.SelectedDate.Value.Date;
     var loadOp = context.Load<ApplicationLog>(context.GetApplicationLogsQuery()
                  .Where(l => l.DateTime.Year <= filterDate.Year
                           && l.DateTime.Month <= filterDate.Month
                           && l.DateTime.Day <= filterDate.Day));
