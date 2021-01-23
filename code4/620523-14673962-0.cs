    private void Draw()
        {
            Random random1 = new Random(unchecked((int)DateTime.Now.Ticks << (int)100));
            int randomNumber1 = random1.Next(0, 300);
            Random random2 = new Random(unchecked((int)DateTime.Now.Ticks << (int)200));
            int randomNumber2 = random2.Next(0, 300);
            Random random3 = new Random(unchecked((int)DateTime.Now.Ticks << (int)300));
            int randomNumber3 = random3.Next(0, 300);
            Random random4 = new Random(unchecked((int)DateTime.Now.Ticks << (int)400));
            int randomNumber4 = random4.Next(0, 300);
            System.Drawing.Graphics g = this.CreateGraphics();
            Pen green = new Pen(Color.Green, 5);
            g.DrawLine(green, new Point(randomNumber1, randomNumber2), new Point(randomNumber3, randomNumber4));
        }
    private void btndraw1_Click(object sender, EventArgs e)
    {
        Draw();
    }
