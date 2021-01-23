     s1.MouseUp += Mouse_Up;
     
     s1.MouseUp -=Mouse_Up;
     
     void Mouse_Click(object sender, MouseEventArgs ea)
     {  
        indexOfPointToMove = -1;   
        s1.LineStyle = LineStyle.Solid;  
        MyModel.RefreshPlot(false);    
        e.Handled = true;  
     }
