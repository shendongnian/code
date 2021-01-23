    RadioButton enable = new RadioButton();
    enable.ID = "enable";
    enable.Text = "Enable";
    enable.AutoPostBack = true;
    enable.GroupName = "enableDisableGroup";
    enable.CheckedChanged += new EventHandler(enableRadioButton_CheckedChanged);
    
    RadioButton disable = new RadioButton();
    disable.ID = "disable";
    disable.Text = "Disable";
    disable.AutoPostBack = true;
    disable.GroupName = "enableDisableGroup";
    disable.CheckedChanged += new EventHandler(disableRadioButton_CheckedChanged);
    
    UpdatePanel upEnableDisable = new UpdatePanel();
    upEnableDisable.UpdateMode = UpdatePanelUpdateMode.Conditional;
    upEnableDisable.ContentTemplateContainer.Controls.Add(enable);
    upEnableDisable.ContentTemplateContainer.Controls.Add(disable);
    
    AsyncPostBackTrigger enableTrigger = new AsyncPostBackTrigger();
    enableTrigger.ControlID = enable.ID;
    enableTrigger.EventName = "CheckedChanged";
    upEnableDisable.Triggers.Add(enableTrigger);
    AsyncPostBackTrigger disableTrigger = new AsyncPostBackTrigger();
    disableTrigger.ControlID = disable.ID;
    disableTrigger.EventName = "CheckedChanged";
    upEnableDisable.Triggers.Add(disableTrigger);
    
    mainDiv.Controls.Add(upEnableDisable);
