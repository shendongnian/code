    AutomationElementCollection windows =  AutomationElement.RootElement.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
            foreach (AutomationElement window in windows)
            {
                if (window.Current.ClassName.Equals("#32770"))   //security dialog
                {
                    AutomationElementCollection certs = window.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty,ControlType.ListItem));
                    foreach (AutomationElement cert in certs)
                    {
                        Console.WriteLine(cert.Current.Name);
                    }
                }
            }
