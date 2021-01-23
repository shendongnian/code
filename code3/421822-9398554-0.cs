    public static AutomationElement GetWindowByName(string name)
    {
        AutomationElement root = AutomationElement.RootElement;
        foreach (AutomationElement window in root.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)))
        {
            if (window.Current.Name.Contains(name) && window.Current.IsKeyboardFocusable)
            {
                return window;
            }
        }
        return null;
    }
