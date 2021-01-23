    private void RefreshingTimerTick(object sender, EventArgs e)
    {
       for (int i = 1; i < 9; i++)
       {
           PictureBox p = 
              (PictureBox)this.tabPage1.Controls["pictureBox_DO" + i.ToString()];
           if(p != null && p.Image != null)
           {  
              p.Image.Dispose();
           }
           bool is_one = (ReceivedDataTextBox.Text[i - 1].ToString() == "1");
           p.Image = (is_one) ? new Bitmap(@"Logos\green.png") : 
              new Bitmap(@"Logos\red.png");
        }
     }
