    private void Scheduler_DoubleClick(object sender, EventArgs e)
        {
            if ((Scheduler.SelectedAppointments != null) &&
                (Scheduler.SelectedAppointments.Count > 0))
            {
                MessageBox.Show("Hallo");
            }
        }
