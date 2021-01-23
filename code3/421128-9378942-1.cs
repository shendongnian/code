    private void button1_Click(object sender, EventArgs e)
            {
                btnSave.Visible = true;
    
                Thread thread = new Thread(new ThreadStart(threadWork));
                thread.Start();
            }
    
            int flag = 0;
    
            private void threadWork()
            {
                while (flag == 0)
                {
                    UpdateImage();
                }
            }
    
            private void UpdateImage()
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(UpdateImage);
                }
                else
                {
                    sendto_bmpbox.Image = CaptureScreen();
                }
            }
