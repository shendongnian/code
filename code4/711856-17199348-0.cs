     public static void ControlsReadOnly(Control [] containerList, bool readOnlyStatus)
        {
            for (int i = 0; i < containerList.Length; i++)
            {
                foreach (var control in containerList[i].Controls)
                {
                    // ignore labels
                    if ((control as RadLabel) != null)  
                    {
                        continue;
                    }
                    // other editable controls
                    else if ((control as RadTextBox) != null)
                    {
                        (control as RadTextBox).ReadOnly = readOnlyStatus;
                        continue;
                    }
                     
                    else if ((control as RadMaskedEditBox) != null)
                    {
                        (control as RadMaskedEditBox).ReadOnly = readOnlyStatus;
                        continue;
                    }
                    // rest of code
