    private void timer_Elapsed(object sender, EventArgs e)
    {
        //Graphics graphic = Graphics.FromImage(pictureBox1.Image); 
        //graphic.RotateTransform(45); 
          
       // this.Invoke(new MethodInvoker(delegate { RotateImage(pictureBox1.Image, 10); }));    
        pictureBox1.Invalidate();
    }
