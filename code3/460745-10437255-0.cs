    protected override void OnManipulationDelta(ManipulationDeltaRoutedEventArgs e)
    {
        // Manipulation delta does not take UI scaling into account
        var scaleString = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.DefaultContext.QualifierValues["scale"];
        var scale = Double.Parse(scaleString) * 0.01;
        var x = _translateOrigin.X + e.Cumulative.Translation.X / scale;
        var y = _translateOrigin.Y + e.Cumulative.Translation.Y / scale;
        if (e.IsInertial)
        {
            while (x < Container.Padding.Left ||
                x > Container.ActualWidth - Container.Padding.Right)
            {
                if (x < Container.Padding.Left)
                    x = -x + 2 * Container.Padding.Left;
                if (x > Container.ActualWidth - Container.Padding.Right)
                    x = 2 * (Container.ActualWidth - Container.Padding.Right) - x;
            }
            while (y < Container.Padding.Top ||
                y > Container.ActualHeight - Container.Padding.Bottom)
            {
                if (y < Container.Padding.Top)
                    y = -y + 2 * Container.Padding.Top;
                if (y > Container.ActualHeight - Container.Padding.Bottom)
                    y = 2 * (Container.ActualHeight - Container.Padding.Bottom) - y;
            }
        }
        _scatterViewItemTransform.TranslateX = x;
        _scatterViewItemTransform.TranslateY = y;
        if (!e.IsInertial)
        {
            BringIntoBounds();
        }
    }
    public void BringIntoBounds()
    {
        if (_scatterViewItemTransform.TranslateX < Container.Padding.Left)
        {
            _scatterViewItemTransform.TranslateX = Container.Padding.Left;
        }
        if (_scatterViewItemTransform.TranslateX > Container.ActualWidth - Container.Padding.Right)
        {
            _scatterViewItemTransform.TranslateX = Container.ActualWidth - Container.Padding.Right;
        }
        if (_scatterViewItemTransform.TranslateY < Container.Padding.Top)
        {
            _scatterViewItemTransform.TranslateY = Container.Padding.Top;
        }
        if (_scatterViewItemTransform.TranslateY > Container.ActualHeight - Container.Padding.Bottom)
        {
            _scatterViewItemTransform.TranslateY = Container.ActualHeight - Container.Padding.Bottom;
        }
    }
