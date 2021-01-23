    private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
       Graphics g = e.Graphics;
       foreach (Ball ball in balls)
       {
           ball.Update();
           g.FillEllipse(ball.Brush, ball.Pos.X - ball.Radius, ball.Pos.Y - ball.Radius, ball.Radius*2, ball.Radius*2);
       }
    }
