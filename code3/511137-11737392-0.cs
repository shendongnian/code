    private void checkTimer_Tick(object sender, EventArgs e)
            {
                checkTimer.Enabled = false;
                MessageBox.Show("Test");   
                for (int i = 0; i < 2000000000; i++)
                {
    
                }
                MessageBox.Show("Test");
                checkTimer.Enabled = true;
            }
