    private void Scheduler_AppointmentDrop(object sender, AppointmentDragEventArgs e)
    {
       if (isAllowed)
       {
          MyDataSource.Add(e.EditedAppointment);
       }
    }
    
    private void Scheduler_DragDrop(object sender, DragEventArgs e)
    {
       SchedulerStorage.RefreshData();
    }
