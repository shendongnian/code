    var act = new Action<object, EventArgs>((e, s) =>
        {
            indexOfPointToMove = -1;
            s1.LineStyle = LineStyle.Solid;
            MyModel.RefreshPlot(false);
            e.Handled = true;
        });
    this.MouseUp += act;
    ...
    this.MouseUp -= act;
