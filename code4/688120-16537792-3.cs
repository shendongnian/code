    public static class FormControls
    {
        public static void CleartheForm(Control groupofcontrols)
        {
            foreach (Control c in groupofcontrols.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                  
                if (c.HasChildren)
                     CleartheForm(c);
                if (c is CheckBox)
                    ((CheckBox)c).Checked = false;
            }
        }
    }
