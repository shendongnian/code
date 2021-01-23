     Form5 f5 = new Form5();
     private void radioButton1_CheckedChanged(object sender, EventArgs e)
     {
        f5.Show();
        f5.label7.Text = label6.Text;
        MyTimer.Interval = 5000; // 0.5 mins
        MyTimer.Tick += new EventHandler(MyTimer_Tick);
        MyTimer.Start();
      }
      private void MyTimer_Tick(object sender, EventArgs e)
      {
        MessageBox.Show("All The Best for Your Test and Your Time Starts Now.");
        Form6 f6 = new Form6();
        f6.Show();
        MyTimer.Enabled = false;
        MyTimer.stop();        
        f5.Hide();
      }
