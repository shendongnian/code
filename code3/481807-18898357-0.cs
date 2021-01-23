    AsyncPostBackTrigger _Trigger = new AsyncPostBackTrigger();
    _Trigger.ControlID = btnButton.ID;
    _Trigger.EventName = "Click";
    
    this.upTheBrazilianRegions.Triggers.Clear();
    this.upTheBrazilianRegions.Triggers.Add(_Trigger);
