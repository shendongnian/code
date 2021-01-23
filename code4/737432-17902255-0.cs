    protected override void OnStart(string[] args)
    {
        Logger.Message("ChkUser", "Service Start", "");
        try {
        CheckUser();
        } catch (Exception e) { 
          Logger.Message("ChkUser", e.Message, "");
        }
    }
