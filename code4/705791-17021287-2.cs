    public Form1(){
        InitializeComponents();
        t.Interval = 1;
        t.Tick += Tick;
    }
    IDataObject data;
    Timer t = new Timer();
    int i = 0;
    private void Tick(object sender, EventArgs e)
    {
         Text = (i++).ToString();
         if (ClientRectangle.Contains(PointToClient(new Point(MousePosition.X, MousePosition.Y))) && MouseButtons == MouseButtons.None)
         {
            t.Stop();
            if (data != null)
            {
               //Process data here
               //-----------------               
               data = null;
            }                                
         }
         else if (MouseButtons == MouseButtons.None)
         {
            data = null;
            t.Stop();
         }
    }
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
       e.Effect = e.AllowedEffect;
       if (data == null)
       {
           data = e.Data;
           t.Start();
       }
    }
