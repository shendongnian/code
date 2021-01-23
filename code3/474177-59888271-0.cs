    private void chtSales_MouseClick(object sender, MouseEventArgs e)
    {
       var r = chtSales.HitTest(e.X, e.Y);
       if(r.ChartElementType == ChartElementType.DataPoint)
       {
           int index = r.PointIndex;
            MessageBox.Show(index.ToString());
        }
    
    }
