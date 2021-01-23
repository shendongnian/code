    private void PanelVisible(string panelName, bool visible)
    {
        var panel = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == panelName);
        if (panel != default(Panel)) panel.Visible = visible;
    }
    
