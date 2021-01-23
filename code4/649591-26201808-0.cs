                foreach (Process firefox in process)
                {
                    // the chrome process must have a window
                    if (firefox.MainWindowHandle == IntPtr.Zero)
                    {
                        return null;
                    }
                    AutomationElement element = AutomationElement.FromHandle(firefox.MainWindowHandle);
                    if (element == null)
                        return null;
                    //search for first custom element
                    AutomationElement custom1 = element.FindFirst(TreeScope.Descendants,
                     new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
                    //search all custom element children
                    AutomationElementCollection custom2 = custom1.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
                    //for each custom child
                    foreach (AutomationElement item in custom2)
                    {
                        //search for first custom element
                        AutomationElement custom3 = item.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
                        //search for first document element
                        AutomationElement doc3 = custom3.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document));
                        
                        if (!doc3.Current.IsOffscreen)
                        {
                            url = ((ValuePattern)doc3.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
                            return url;
                        }                      
                    }
                }             
                return url
