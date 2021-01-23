    /// <summary>  
    /// Gets the toggle state of an element in the target application.  
    /// </summary> 
    /// <param name="element">The target element.</param>  
    private bool IsElementToggledOn(AutomationElement element)
    {
    if (element == null)
    {
        // TODO: Invalid parameter error handling. 
        return false;
    }
    Object objPattern;
    TogglePattern togPattern;
    if (true == element.TryGetCurrentPattern(TogglePattern.Pattern, out objPattern))
    {
        togPattern = objPattern as TogglePattern;
        return togPattern.Current.ToggleState == ToggleState.On;
    }
    // TODO: Object doesn't support TogglePattern error handling. 
    return false;
    }  
