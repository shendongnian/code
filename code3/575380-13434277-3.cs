    private void PanelVisible(string panelName)
    {
        foreach(var panel in this.Controls.OfType<Panel>().Where(p=>p.Name!="pnlBottom"))
        {
            panel.Visible = panel.Name == panelName;
        }
    }
