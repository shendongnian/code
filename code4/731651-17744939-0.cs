    var element = AutomationElement.RootElement.FindFirst(
                    TreeScope.Descendants,
                    new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button), new PropertyCondition(AutomationElement.NameProperty, "Start", PropertyConditionFlags.IgnoreCase))
                );
    var pattern = (InvokePattern)element.GetCurrentPattern(InvokePattern.Pattern);
    pattern.Invoke();
