            // get to ROW X (here it's row #1 name is always "Row X")
            AutomationElement row1 = dataGrid.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Row 1"));
            
            // get row header
            AutomationElement row1Header = row1.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header));
            // invoke it (select the whole line)
            ((InvokePattern)row1Header.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
