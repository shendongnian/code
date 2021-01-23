    private System.Threading.Timer keyEntryTimer = new Timer(Logic,null,-1,-1);
    
    public void HandleEvent(objet sender, EventArgs args)
    {
        keyEntryTimer.Change(500,-1);
    }
    
    public void Logic(objet state)
    {
        //Your task logic would go here to read from the text etc... 
        //You'll have to handle any UI updates either by firing off a task once the DB results return or using a dispatcher
    }
