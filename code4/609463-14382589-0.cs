        public bool MyTab_GetVisible(Office.IRibbonControl control)
        {
            if (control.Context is Outlook.ContactItem)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
