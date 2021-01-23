    private void timer1_Tick(object sender, EventArgs e)
    {
         timer1.Stop();
         if (File.Exists(patch_to_checked))
         {
              MessageBox.Show("File Found!");
         }
        else
         {
            timer1.Start();
         }
    }
