    private IList<string> GetValues()
    {
        List<string> values = new List<string>();
        TextBox txt = null;
        foreach (ListViewItem item in this.lvDynamicTextboxes.Items)
        {
            if (item is ListViewDataItem)
           {
                txt = (TextBox)item.FindControl("txtText");
                values.Add(txt.Text);
            }
        }
        return values;
    }
