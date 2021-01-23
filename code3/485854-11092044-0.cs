    private void pictureBox1_MouseDown(object sender, 
                                       MouseEventArgs m, 
                                       EventArgs e, 
                                       PaintEventArgs q)
    {
        if (m.Button == System.Windows.Forms.MouseButtons.Left)
        {
            Point currpoint = System.Windows.Forms.Cursor.Position;
    
            Point origin = new Point(0, 0);
    
            decimal sizee = nud.Value;
    
            int size = Convert.ToInt32(sizee);
    
            Random randonGen = new Random();
    
            Color randomColor = Color.FromArgb(randonGen.Next(255),
                                               randonGen.Next(255),
                                               randonGen.Next(255));
    
            Pen selPen = new Pen(randomColor, size);
    
            using(Graphics g = pictureBox1.CreateGraphics()) // Use the CreateGraphics method to create a graphic and draw on the picture box. Use using in order to free the graphics resources.
            {
                 g.DrawLine(selPen, 3, 3, 133, 133);
            }
        }
    }
