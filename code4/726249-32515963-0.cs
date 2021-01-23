    private void OnFocusChange(object sender, AutomationFocusChangedEventArgs e)
    {
        var element = sender as AutomationElement;
        if (element == null) return;
        Automation.AddAutomationPropertyChangedEventHandler(element, Treecope.Element, OnChange, AutomationElement.NameProperty, ...);
        if (element.GetSupportedPatterns().Any(p => p.Equals(InvokePattern.Pattern)))
            Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, element, TreeScope.Element, OnClicked);
        var window = element.Current.ControlType.Equals(ControlType.Window) ? element : GetElementWindow(element);
            Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, window, TreeScope.Element, OnClosed);
    }
