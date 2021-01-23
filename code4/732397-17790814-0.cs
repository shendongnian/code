    style.Setters.Add(new EventSetter(PreviewMouseLeftButtonDownEvent, 
      new MouseButtonEventHandler(Input_Down)));
    private void Input_Down(object sender, RoutedEventArgs e)
    {
        if (EventTriggeredByButtonWithCommand(e))
            return;
    
        var draggedItem = sender as FrameworkElement;
    
        if(draggedItem !=null)
            StartDrag(draggedItem);
    
    }
    bool EventTriggeredByButtonWithCommand(RoutedEventArgs e)
    {
        var frameWorkElement = e.OriginalSource as FrameworkElement;
    
        if (frameWorkElement == null) 
            return false;
    
        var button = frameWorkElement.TemplatedParent as Button;
    
        if (button == null) 
            return false;
    
        return button.Command != null;
    }
