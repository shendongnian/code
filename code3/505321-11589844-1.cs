    if (systemday == day1 || systemday == day2)
    { 
        if(systemtime>=timestart && systemtime <=timeend)
        {
            MessageBox.Show("Your password is ...", "Get Password Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            return;
        }
        else
        {
            MessageBox.Show("You are not authenticated to view your password.", "Get Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
