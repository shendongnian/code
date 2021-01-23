    public void SetVisibility(UIElement parent)
    {
        var childNumber = VisualTreeHelper.GetChildrenCount(parent);
        for (var i = 0; i <= childNumber - 1; i++)
        {
            var uiElement = VisualTreeHelper.GetChild(parent, i) as UIElement;
            var surfaceTextBox = uiElement as SurfaceTextBox;
            // Set your criteria here
            if (surfaceTextBox != null && surfaceTextBox.Name != "A")
            {
                uiElement.Visibility = Visibility.Collapsed;
            }
            if (uiElement != null && VisualTreeHelper.GetChildrenCount(uiElement) > 0)
            {
                SetVisibility(uiElement);
            }
        }
    }
