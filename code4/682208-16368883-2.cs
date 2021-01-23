            Process notepad = Process.Start("notepad");
            
            Thread.Sleep(5000);
            SendKeys.SendWait("^o"); //ctrl+o to open the File Dialog
            var notepadTextBox = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, 
                new PropertyCondition(AutomationElement.AutomationIdProperty, "1148"));
            object valuePattern = null;
            if (notepadTextBox.TryGetCurrentPattern(ValuePattern.Pattern, out valuePattern))
            {
                ((ValuePattern)valuePattern).SetValue("THERE YOU GO"); // this text will be entered in the textbox
            }
            else 
            {
                //ERROR
            }
