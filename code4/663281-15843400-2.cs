    public Form1()
    {           
      InitializeComponent();            
      panel2.Paint += new letsPaint;
    }
    private void panel2_MouseMove(object sender, MouseEventArgs e)
    {
      if (isDragging) {
        mouseMoveX = e.X;
        mouseMoveY = e.Y;                               
        panel2.Invalidate();
      }
    }
