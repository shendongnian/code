    System.Text.StringBuilder sb;
    private int x,TextSize;
    
    public Form1()
    {
         InitializeComponent();
         sb = new System.Text.StringBuilder(label2.Text + " ");
         x = this.ClientRectangle.Width;
         TextSize = 16;
    }
    
    private void Button1_Click(object sender, EventArgs e)
    {
        timer1.Tag = sb.ToString();
        timer1.Enabled = true;
    }
    
    void timer1_Tick(object sender, EventArgs e)
    {
        Form1_Paint(this,null);
    }
    
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
            
         string str = timer1.Tag.ToString();
         Graphics g = Graphics.FromHwnd(this.Handle);
         g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
         g.FillRectangle(Brushes.Black, this.ClientRectangle);
         g.DrawString(str, new Font("Arial", TextSize), new SolidBrush(Color.White), x, 5);
         x -= 5;
    
         if (x <= str.Length * TextSize * -1)
             x = this.ClientRectangle.Width;
            
        }
