    private void LockApplication()
    {
        try 
        {
            lockdownTimer.Stop();
            calloutsReminderTimer.Stop();
            .....
            if (result == DialogResult.OK)
            {
                ......
                lockdownTimer.Start();
                calloutsReminderTimer.Start();
            }
            else
                fileExitMenuItem.PerformClick();
        }
        catch (Exception ex)
        {
            Helper.LogError(ex);
            lockdownTimer.Start();
            calloutsReminderTimer.Start();
        }
        // remove the finally clause
    }
