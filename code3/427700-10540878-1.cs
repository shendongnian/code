     BindingList<DashboardReminder> reminders
     public void Setup()
        {
          grdDashboard.SetDataBinding(reminders, "RootTable");
        }
     public void FetchReminders()
        {
            BindingList<DashboardReminder> reminders2 = DashboardReminder.GetReminders(1, true);
            //add your own code to import contents of reminders2 into reminders
    }
