    Panel visiblePanel = new Panel();
    visiblePanel.Style.Add("background-color", "red");
    visiblePanel.CssClass = "visiblePanel";
    this.Controls.Add(visiblePanel);
    Panel invisiblePanel = new Panel();
    invisiblePanel.CssClass = "invisiblePanel";    
    this.Controls.Add(visiblePanel);
