    private int counter = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            counter++;
            if (counter/5 = 1)
              PaintOnChartPanel();
            
        }
    private void PaintOnChartPanel()
    {
        IntPtr hwnd = panel1.Handle;  
    
        using (Graphics graphics = Graphics.FromHwnd(hwnd))
        {   //position according to the previous square or any x,y starting points
            graphics.DrawRectangle(new Pen(Color.Red, 1), 1, 1, 20, 20);
        }
    }
