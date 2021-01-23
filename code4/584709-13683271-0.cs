    private IEnumerable<string> SelectedValues
    {
        get
        {
            if (ViewState["SelectedValues"] == null && dtlstfilter.SelectedIndex >= -1)
            {
                ViewState["SelectedValues"] = dtlstfilter.Items.Cast<ListItem>()
                    .Where(li => li.Selected)
                    .Select(li => li.Value)
                    .ToList();
            }else
                ViewState["SelectedValues"]  = Enumerable.Empty<string>();
            return (IEnumerable<string>)ViewState["SelectedValues"];
        }
        set { ViewState["SelectedValues"] = value; }
    }
    protected void chklist_SelectedIndexChanged(Object sender, EventArgs e)
    {
        CheckBoxList c = (CheckBoxList)sender;
        var oldSelection = this.SelectedValues;
        var newSelection = c.Items.Cast<ListItem>()
                    .Where(li => li.Selected)
                    .Select(li => li.Value);
        var uncheckedItems = newSelection.Except(oldSelection);
    }
