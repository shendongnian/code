    DateTime startDate = DateTime.Today.AddMonths(-3);
    
    for (Int32 indexer=0; indexer < 3; indexer++) {
      ddlPayrollDate.Items.Add(String.Format("{0:MMMM dd, yyyy}", new DateTime(startDate,Year, startDate.Month, 2)));
    ddlPayrollDate.Items.Add(String.Format("{0:MMMM dd, yyyy}", new DateTime(startDate,Year, startDate.Month, 17)));
    startDate = startDate.AddMonth(1);
    }
