    enum Sender
    {
    	Shortcut,
    	Menu
    }
    
    void MenuEvent(Sender sender)
    {
    	if (sender == Sender.Shortcut)
    	{
    
    	}
    	else
    	{
    		
    	}
    }
    
    //if you click from the menu
    void btnMenuClick()
    {
    	MenuEvent(Sender.Menu);
    }
    
    //if you use shortcut
    void OnShortcutEvent()
    {
    	MenuEvent(Sender.Shortcut);
    }
