    PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
    
    PhoneApplicationPage page = (PhoneApplicationPage)frame.Content;
    
    // Save the transitions
    
    NavigationInTransition oldIn = TransitionService.GetNavigationInTransition(page);
    
    NavigationOutTransition oldOut = TransitionService.GetNavigationOutTransition(page);
    
    // Clear the transitions
    
    TransitionService.SetNavigationInTransition(page, null);
    
    TransitionService.SetNavigationOutTransition(page, null);
    
    // Restore the transitions
    
    TransitionService.SetNavigationInTransition(page, oldIn);
    
    TransitionService.SetNavigationOutTransition(page, oldOut);
