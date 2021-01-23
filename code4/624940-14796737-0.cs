    public override void OnLoad(Object sender, EventArgs e) {
        
        this.panel1.AutoScrollPosition = GetSavedScrollPoint();
        
    }
    
    public override void OnFormClosing(Object sender, EventArgs e) {
        
        SavePointSomewhere( this.panel1.AutoScrollPosition );
    }
