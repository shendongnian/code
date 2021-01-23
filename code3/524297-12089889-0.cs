        protected void AddActionPanel(ActionPanel panel)
        {
            var count = PanelsList.IndexOf(panel);
            var panel1 = new ActionPanel(count, ScriptManager1);
            
            var button_index = DataActionsPanel.Controls.IndexOf(button);
            DataActionsPanel.Controls.AddAt(count, panel1.GetPanel());
        }
