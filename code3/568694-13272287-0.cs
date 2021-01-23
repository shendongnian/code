    private void ItemsControl_SizeChanged(object sender, SizeChangedEventArgs e)
        if (double.IsNaN(ClippingContainer.Height))
        {
            ClippingContainer.Height = e.NewSize.Height;
        }
        else
        {
            ClippingContainer.BeginAnimation(FrameworkElement.HeightProperty, new DoubleAnimation(e.NewSize.Height, new Duration(TimeSpan.FromSeconds(1))));
        }
        if (double.IsNaN(ClippingContainer.Width))
        {
            ClippingContainer.Width = e.NewSize.Width;
        }
        else
        {
            ClippingContainer.BeginAnimation(FrameworkElement.WidthProperty, new DoubleAnimation(e.NewSize.Width, new Duration(TimeSpan.FromSeconds(1))));
        }
    }
