    MyControl control1 = new MyControl();
    ... your setup code for control1...
    Dim containerGrid As New Grid
    containerGrid.Children.Add(control1)
    containerGrid.Measure(New Size(Double.MaxValue, Double.MaxValue))
    containerGrid.Arrange(New Rect(0, 0, Double.MaxValue, Double.MaxValue))
    ...now check the grid.ActualWidth and grid.ActualHeight
