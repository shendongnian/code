        public  void ClearTextItems(ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is System.Web.UI.WebControls.TextBox)
                {
                    TextBox t = c as TextBox;
                    t.Text = string.Empty;
                }
            }
         }
