    private void btnUpdate_Click(object sender, EventArgs e)
    {
        using (testEntities Setupctx = new testEntities())
        {
            int ID = Int32.Parse(lblID.Text);
            var ESquery = (from es in Setupctx.employeeshifts
                           where es.EmployeeShiftID == ID
                           select es).First();
    		var SHquery = (from sh in Setupctx.shifthours where sh.idShiftHours == ESQuery.ShiftHourID 
                          select sh).First();
    
            ESquery.StartTime = txtStart.Text;
            ESquery.EndTime = txtStop.Text;
            ESquery.Date = txtDate.Text;
    		SHquery.shiftTiming_start = ESquery.StartTime;
    		SHquery.shiftTiming_stop = ESquery.EndTime;
            Setupctx.SaveChanges();
            txtStart.Text = "";
            txtStop.Text = "";
            txtDate.Text = "";
            this.Edit_Employee_Shift_Load(null, EventArgs.Empty);
            MessageBox.Show("Employee's Shift Has Been Updated.");
        }
    }
