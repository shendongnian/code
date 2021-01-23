    Private void menuItem1_Click(object sender, EventArgs e)
    {
        String oemVersion = oemver.getOEMVersion();
        String myVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        if (myVersion.Equals(oemVersion))
        {
            if (checkBox1.Checked)
                wipefiles();
            else
            {
                if (myThread == null)
                {
                    label4.Visible = false;
                    pictureBox1.Enabled = false;
                    SystemIdleTimerReset();
                    menuItem1.Enabled = false;
                    myThread = new Thread(MyWorkerThread);
                    myThread.IsBackground = true;
                    myThread.Start();
                }
            }
        }
        else
        {
            MessageBox.Show("Install firmware");
        }
    }
