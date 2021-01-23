    FilterPanel.IsMouseCaptureWithinChanged +=FilterPanel_IsMouseCaptureWithinChanged;
    void FilterPanel_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
            { FilterPanel.IsOpen = false; } 
        }
