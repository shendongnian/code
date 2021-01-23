    private void button1_Click(object sender, EventArgs e)
    {
        int centerX;
        int centerY;
        int radius;
            
        if (!int.TryParse(textBox2.Text, out centerX))
            return;
        if (!int.TryParse(textBox3.Text, out centerY))
            return;
        if(! int.TryParse(textBox1.Text,out radius))
            return;
        Point center = new Point(centerX, centerY);
        Graphics paper; 
        paper = pictureBox1.CreateGraphics(); 
        Pen pen = new Pen(Color.Black); 
        getCircle(paper, pen, center, radius); 
            
    }
    private void getCircle(Graphics drawingArea, Pen penToUse, Point center, int radius) 
    { 
        Rectangle rect = new Rectangle(center.X-radius, center.Y-radius,radius*2,radius*2); 
        drawingArea.DrawEllipse(penToUse,rect);
    }  
