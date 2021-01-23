    ![private void FrmWeb_Btn_Click(object sender, EventArgs e)
            {
                
    
                PictureBox PB = new PictureBox();
    
                PB.ImageLocation =  "https://si0.twimg.com/profile_images/378800000038434114/f676cbea6f8500c9c15529e1d5e548c1_reasonably_small.jpeg";
                PB.Size = new Size(100, 100);
                Controls.Add(PB);
    
                PB.Click +=new EventHandler(PB_Click); 
    
    
            }
    
            protected void PB_Click(object sender, EventArgs e)
            {
    
                webBrowser1.Navigate("http://twit.tv/");
    
            }][2]
