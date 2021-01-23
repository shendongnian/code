    int UniqueId = 0;
    List<CustomTick> MyCustomTicks = new List<CustomTick>();
    Thumb MySliderThumb;
    Point ThumbCurrentPoint;
    private void MySlider_Loaded_1(object sender, RoutedEventArgs e)
    {
        FrameworkElement templateRoot = VisualTreeHelper.GetChild((Slider)sender, 0) as FrameworkElement;
        MySliderThumb = templateRoot.FindName("HorizontalThumb") as Thumb;
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        MySliderThumb.TransformToVisual(MyCanvas).TryTransform(new Point(0, 0), out ThumbCurrentPoint);
        CustomTick MyCustomTick = new CustomTick();
        MyCustomTick.X = ThumbCurrentPoint.X;
        MyCustomTick.Y = ThumbCurrentPoint.Y;
        MyCustomTick.Value = MySlider.Value;
        MyCustomTick.ID = UniqueId++;
        MyCustomTicks.Add(MyCustomTick);
        Windows.UI.Xaml.Shapes.Rectangle MyRectangle = new Windows.UI.Xaml.Shapes.Rectangle();
        MyRectangle.Name = MyCustomTick.ID.ToString();
        MyRectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
        MyRectangle.Width = MySliderThumb.ActualWidth;
        MyRectangle.Height = MySliderThumb.ActualHeight;
        MyRectangle.PointerPressed += MyRectangle_PointerPressed;
        MyCanvas.Children.Add(MyRectangle);
        Canvas.SetTop(MyRectangle, MyCustomTick.Y - MyRectangle.Height );
        Canvas.SetLeft(MyRectangle, MyCustomTick.X);
    }
    void MyRectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Xaml.Shapes.Rectangle MyRectangle = sender as Windows.UI.Xaml.Shapes.Rectangle;
        CustomTick MyCustomTick = new CustomTick();
        foreach (CustomTick CT in MyCustomTicks)
        {
    if (CT.ID.ToString() == MyRectangle.Name)
    {
        MyCustomTick = CT;
        break;
    }
        }
        MySlider.Value = MyCustomTick.Value;
    }
           
    List<CustomTick> MyTicks = new System.Collections.Generic.List<CustomTick>();
    private class CustomTick
    {
        public double X;
        public double Y;
        public double Value;
        public int ID;
    }
