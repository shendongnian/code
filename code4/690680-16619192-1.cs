    private void reduceGridWidth_Click(object sender, RoutedEventArgs e)
    {
        // start handling event
        CompositionTarget.Rendering += CompositionTarget_Rendering;
    }
    
    void CompositionTarget_Rendering(object sender, object e)
    {
        col1.Width = new GridLength(col1.Width.Value - 20);
    
        // when the Width hits zero, we stop handling event
        if (col1.Width.Value == 0)
        {
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
        }
    }
