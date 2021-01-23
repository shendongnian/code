    VisualTreeHelper.HitTest(
        Application.Current.MainWindow,
        obj =>
        {
            if (obj is UserControl)
            {
                // found it
                return HitTestFilterBehavior.Stop;
            }
            return HitTestFilterBehavior.Continue;
        },
        result => HitTestResultBehavior.Continue,
        new PointHitTestParameters(_currentPoint));
