    ScriptManager scriptManager = ScriptManager.GetCurrent(this);
    var cbx = (CheckBox)e.Item.FindControl("checkbox1") ;
    if(cbx != null)
    {
        cbx.CheckedChanged+= CheckBox1_CheckedChanged;
        scriptManager.RegisterAsyncPostBackControl(cbx);
    }
