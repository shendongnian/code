    s1.MouseUp += s1_MouseUp; //subscribe
    s1.MouseUp -= s1_MouseUp; //ussubscribe
    
    
    private void s1_MouseUp(object sender, MouseEventArgs e)
    {
       indexOfPointToMove = -1;
       s1.LineStyle = LineStyle.Solid;
       MyModel.RefreshPlot(false);
       e.Handled = true;
    }
