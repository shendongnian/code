     public void PopulateDashboard()
     {
         grdDashboard.SetDataBinding(Nothing, Nothing)
         List<DashboardReminder> reminders = DashboardReminder.GetReminders(1, true);
         grdDashboard.SetDataBinding(reminders, "RootTable");
     }
