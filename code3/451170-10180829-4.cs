    protected override void OnInit(EventArgs e)
    {
        var chk = new CheckBox { ID = "chkBox1" };                 
        PlaceHolder1.Controls.Add(chk);
        base.OnInit(e);
    }    
