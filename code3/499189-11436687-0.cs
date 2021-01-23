    public void SetVisibility(UIElement parent)
    {
        var childNumber = VisualTreeHelper.GetChildrenCount(parent);
        for (var i = 0; i <= childNumber - 1; i++)
        {
            var uiElement = (UIElement)VisualTreeHelper.GetChild(parent, i);
            var surfaceTextBox = uiElement as SurfaceTextBox;
            // Set your criteria here
            if (surfaceTextBox != null && surfaceTextBox.Name != "A")
            {
                uiElement.Visibility = Visibility.Collapsed;
            }
            if (VisualTreeHelper.GetChildrenCount(uiElement) > 0)
            {
                SetVisibility(uiElement);
            }
        }
    }
