        DateTime dt;
        try
        {
            dt = Convert.ToDateTime(txtViewDate.Text).AddHours(txtViewTime.Hour).AddMinutes(txtViewTime.Minute);
            if (txtViewTime.AmPm == MKB.TimePicker.TimeSelector.AmPmSpec.PM)
            {
                dt = dt.AddHours(12);
            }
            System.Diagnostics.Debug.WriteLine(dt.ToString());
        }
        catch (Exception)
        {
            // abort processing
            return;
        }  
