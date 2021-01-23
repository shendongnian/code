    ClearInputFields(this);
    private List<Control> ControlsForPage(Control Page)
    {
            List<Control> result = new List<Control>();
            foreach (Control ctrl in Page.Controls)
                  result.Add(ctrl);
            return result;
    {
    private void ClearInputFields(Control Page)
    {
        try
        {
            List<Control> ctrlsCopy = ControlsForPage(Page);
            foreach (Control ctrl in ctrlsCopy)
            {
                if (ctrl is Button)                    
                    continue;
                if (ctrl is DataGridView)
                    continue;
                if (ctrl is ListBox)
                    continue;
                if (ctrl is TextBox)
                {
                    ((TextBox)(ctrl)).Text = string.Empty;
                }
                else if (ctrl is ComboBox)
                {        
                    ((ComboBox)(ctrl)).SelectedIndex = 0;
                }
                else if (ctrl is CheckBox)
                {
                    ((CheckBox)(ctrl)).Checked = false;
                }
                else if (ctrl.Controls.Count > 0)
                {
                    ClearInputFields(ctrl);
                }                                       
            }
        }
        catch (Exception ex)
        {
            TraceFile.Error("ExceptionLog", ex);
        }
    }
