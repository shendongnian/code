    private void PanelVisible(string panelName)
    {
        foreach(var panel in this.Controls.OfType<Panel>())
            panel.Visible = panel.Name == panelName;
    }
