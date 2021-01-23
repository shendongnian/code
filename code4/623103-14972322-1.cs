    // original code
    CheckBox chkModuleID = new CheckBox();
    chkModuleID.ID = drNew[def.ID].ToString();
    chkModuleID.AutoPostBack = true;
    chkModuleID.CheckedChanged += new EventHandler(chkID_OnRow_Check);
    pnlCheckList.Controls.Add(chkModuleID);
    // register the control to cause asynchronous postbacks
    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(chkModuleID);
