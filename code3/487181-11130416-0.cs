    public PointCtrlRowSelectionForm(Dictionary<CheckBox, Boolean> checkList, PointCtrlForm form, string title)
            {
                InitializeComponent();
                this.form = form;
                this.Text = title;
                foreach<KeyValuePair<CheckBox, Boolean> kvp in checklist)
                {
                    if (kvp.Value == true)      
                    {
                        kvp.Key.Checked = true;
                        kvp.Key.CheckState = CheckState.Checked;
                    }
                }
            }
