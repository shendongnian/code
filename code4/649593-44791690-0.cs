                    AutomationElement element = AutomationElement.FromHandle(intPtr);  // intPtr is the MainWindowHandle for FireFox browser
                    element = element.FindFirst(TreeScope.Subtree,
                          new AndCondition(
                              new PropertyCondition(AutomationElement.NameProperty, "Search or enter address"),
                              new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)));
                    string url = ((ValuePattern)element.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
