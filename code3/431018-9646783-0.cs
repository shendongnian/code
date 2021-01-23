    ToolTip tt = new ToolTip();
    tt.SetToolTip(pic, " ");
    tt.ShowAlways = true;
    
     private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
     {
        tt.ToolTipTitle = e.X + "  " + e.Y; 
     }
