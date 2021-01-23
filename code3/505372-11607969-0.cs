        {
                if( timercheckbox.Enabled == true )
                {
                    
                    timercheckbox.Enabled = false;
                    button1.Text = "Start Auto save";
                }
                else
                {
                timercheckbox.Interval = (int)numericChnageTime.Value;
                timercheckbox.Enabled = true;
                checkBoxWMVFile.Checked = true;
                button1.Text = "Stop Auto save";
        
            }
        }
