            if (checkBox1.Checked && myString == "86.09.0000")
            {
                wipefiles();
            }
            else if ((checkBox1.Checked == false) && (myString == "86.09.0000"))
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
            else
                {
                    MessageBox.Show("Install firmware");
                }
