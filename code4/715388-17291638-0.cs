    private void Form1_KeyDown(object sender, KeyEventArgs e) 
    {
            Point l;
    
            if(e.KeyCode == Keys.Up)
            {
                l = new Point(ImgGuy.Location.X, ImgGuy.Location.Y - 1);
            }
            else if (e.KeyCode == Keys.Down)
            {
                l = new Point(ImgGuy.Location.X, ImgGuy.Location.Y + 1);
            }
            else if (e.KeyCode == Keys.Left)
            {
                l = new Point(ImgGuy.Location.X - 1, ImgGuy.Location.Y);
            }
            else if (e.KeyCode == Keys.Right)
            {
                l = new Point(ImgGuy.Location.X + 1, ImgGuy.Location.Y);
            }
            
            ImgGuy.Location = l;
    }
