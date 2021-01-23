        protected override bool ProcessDialogKey(Keys keyData)
        {
            System.Diagnostics.Debug.WriteLine(keyData.ToString());
            switch (keyData)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
            }
            base.ProcessDialogKey(keyData);
            return false;
        }
