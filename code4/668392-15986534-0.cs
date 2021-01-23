                PictureBox picturebox = new PictureBox();
                picturebox.Width = 400;
                picturebox.Name = "picturebox" + i;
                picturebox.Height = 15;
                picturebox.Paint+=new PaintEventHandler(picturebox_Paint);
    
          void picturebox_Paint(object sender, PaintEventArgs e)
            {
               Graphics g=e.Graphics;
               //Put your drawing code here
            }
