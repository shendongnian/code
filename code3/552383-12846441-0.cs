        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (original_image != null)
            {
                Graphics g = e.Graphics;
                Rectangle r = new Rectangle(10, 50, original_image.Width, original_image.Height);
                g.DrawImage(original_image, r);
    
    
            }
            if(proc_image != null)
            {
                Rectangle r = new Rectangle(535, 50, original_image.Width, original_image.Height);
                e.Graphics.DrawImage(proc_image, r);
            }
        }
