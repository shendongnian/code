    private void Grid_SizeChanged_1(object sender, SizeChangedEventArgs e)
    {
        e.Handled = true;
        BeginAnimation(HeightProperty, new System.Windows.Media.Animation.DoubleAnimation(e.NewSize.Height, new Duration(TimeSpan.FromSeconds(1))));
    }
