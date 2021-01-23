    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
        SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
    
        Graphics panelGraphics = e.Graphics; //use the provided Graphics object
    
        // create an internal bitmap to draw rectangles to
        Bitmap bmp = new Bitmap(this.ClientSize.Width, _
                                this.ClientSize.Height, _
                                Imaging.PixelFormat.Format32bppPArgb);
        using (Graphics g = Graphics.FromImage(bmp)) {
    
            PointF ptPrevious = new PointF(float.MaxValue, float.MaxValue);
            foreach (PointF pt in _listPoint) {
                g.FillRectangle(myBrush, (pt.X / 25) * _fZoomFactor, _
                                         (pt.Y / 25) * _fZoomFactor, 2, 2);
    	    }	
    	}
    	
        panelGraphics.TranslateTransform((panel1.ClientSize.Width / 2) + _panW, _
                                         (panel1.ClientSize.Height / 2) + _panH);
    
        //Problematic line...
        panelGraphics.RotateTransform(230 - Convert.ToInt32(_dPan), _
                                      System.Drawing.Drawing2D.MatrixOrder.Prepend);
    
        panelGraphics.DrawImage(bmp, 0, 0);
        bmp.Dispose;
    
        myBrush.Dispose();
        myPen.Dispose();
    }
