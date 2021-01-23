        private void setText(AutomationElement aEditableTextField, string aText)
        {
            ValuePattern pattern = aEditableTextField.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (pattern != null)
            {
                pattern.SetValue(aText);
            }
        }
