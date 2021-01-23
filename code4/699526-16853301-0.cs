            AutomationElement windowEl = AutomationElement.FromHandle(handle);
            AutomationElement editEl = windowEl.FindFirst(
                TreeScope.Descendants, 
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            ValuePattern vp = (ValuePattern) editEl.GetCurrentPattern(ValuePattern.Pattern);
            string str = vp.Current.Value;
