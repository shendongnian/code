	AutomationElement aeForm = AutomationElement.FromHandle(windowPtr);
	AutomationElementCollection buttonCollection = aeForm.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ScrollBar));			
			
	AutomationElement aeButton = buttonCollection[1];
	RangeValuePattern rcpattern = (RangeValuePattern)aeButton.GetCurrentPattern(RangeValuePattern.Pattern);
	rcpattern.SetValue(50.00);
