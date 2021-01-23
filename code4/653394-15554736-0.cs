    protected override OnInit(EventArgs e)
    {
        for (int i = 0; i < 5; i++)
        {
            var chk = new CheckBox();
            chk.CheckedChanged += this.CheckBoxChanged;
            chk.Text = "CHK#" + i.ToString();
            chk.ID = "chk_" + i.ToString();
    
            this.Controls.Add(chk);
        }
    }
    
    protected void CheckBoxChanged(object sender, EventArgs e)
    {
        var chk = (CheckBox)sender;
        var i = int.Parse(chk.ID.SubString(4));
        // "i" now holds the number of the checkbox changed.
    }
