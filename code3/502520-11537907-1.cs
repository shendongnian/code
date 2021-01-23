    private void timer1_Tick(object sender, EventArgs e)  
        {  
            if (port.IsOpen)  
            {
               string s = port.ReadExisting();
               
                   if (s.Contains("\r\nRING\r\n"))
                   {
                       incall_status.Text = "Incoming Call....";
                       incall_status.Visible = true;
                   }
                   else if (s.Contains("\r\nNO CARRIER\r\n"))
                   {
                       incall_status.Text = "Call Disconnected";
                       bgwrkr_calldisconect.RunWorkerAsync();
                   }
               
            }
        }
      
