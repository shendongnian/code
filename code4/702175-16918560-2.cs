    public string Name {get; private set;}
    public string Age {get; private set;}
    public string Gender {get; private set;}
    
    private void btnSelect_Click(object sender, EventArgs e)
    {
        if (lvlist.Items.Count < 1) { this.DialogResult = DialogResult.None; return; }
        this.Name = lvlist.FocusedItem.Text;
        this.Age = lvlist.FocusedItem.SubItems[1].Text;
        this.Gender = lvlist.FocusedItem.SubItems[2].Text;
        this.DialogResult = DialogResult.OK;  
    }
