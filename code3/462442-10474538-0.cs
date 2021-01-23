    private ToolTip tt= new ToolTip();
    
    string rollText;
    int mouseX;
    int mouseY; 
    private void Picture_MouseEnter(object sender, MouseEventArgs e)
    {
       
        //tt.SetToolTip(Picture, rollText);//option 1
        tt.Show();//option 2
    }
    private void Picture_MouseMove(object sender, MouseEventArgs e)
    {   
        mouseX=e.X;
        mouseY=e.Y;
        string rollText = ("Mouse position is:  X:"+mouseX+" Y:"+mouseY);
       tt.SetToolTip(Picture, rollText);//option 2
            
    }
