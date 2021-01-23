    public string FocusedItem {get; private set;}
    public string FocusedSubItem1 {get; private set;}
    public string FocusedSubItem2 {get; private set;}
    
    private void btnSelect_Click(object sender, EventArgs e)
    {
        if (lvlist.Items.Count < 1) { this.DialogResult = DialogResult.None; return; }
        this.FocusedItem = lvlist.FocusedItem.Text;
        this.FocusedSubItem1 = lvlist.FocusedItem.SubItems[1].Text;
        this.FocusedSubItem2 = lvlist.FocusedItem.SubItems[2].Text;
        this.DialogResult = DialogResult.OK;  
    }
