    private void Rect2_ManipulationDelta_1(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        Rect2Transform.TranslateX += e.Delta.Translation.X;
        Rect2Transform.TranslateY += e.Delta.Translation.Y;
        var _Visual = Rect2.TransformToVisual(this);
        var _Location = _Visual.TransformPoint(new Point());
        Rect1.SetValue(Canvas.LeftProperty, _Location.X);
        Rect1.SetValue(Canvas.TopProperty, _Location.Y - 100);
    }
