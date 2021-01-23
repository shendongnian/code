    ChartArea _chartarea;
    Series _data;
    private void Plot_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        HitTestResult result = _plot.HitTest(e.X, e.Y);
        if (result.ChartElementType == ChartElementType.DataPoint && result.ChartArea == _chartarea && result.Series == _data)
        {
            // A point is selected.
        }
    }
