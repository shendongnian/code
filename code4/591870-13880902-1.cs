    void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            // output will be in string e.Data
            if (e.Data != null)
            {
                string Data = e.Data.ToString();
                if (Data.Contains("Enter Auth Username"))
                {
                    if (myStreamWriter != null) // Just in case
                    {
                        myStreamWriter("myusername");
                    }
                }
                //MessageBox.Show(Data);
            }
        }
