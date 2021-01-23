        // Call BeginUpdate to prevent the display from
        // refreshing as we add individual tabs.
        // Note: This MUST be paired with a call to
        // EndUpdate below.
        this.ultraTabControl1.BeginUpdate();
                
        UltraTab tabAdded;
        UltraTabsCollection tabs = this.ultraTabControl1.Tabs;
        // Add a tab to the Tabs collection
        tabAdded = tabs.Add("options", "&Options");
        // Create a new control
        TextBox tb = new TextBox();
        tb.Location = new Point(20,20);
        tb.Size = new Size(80, 20);
        
        // Add the control to the tab's tab page
        tabAdded.TabPage.Controls.Add(tb );
        // Call EndUpdate to allow the display to refresh
        this.ultraTabControl1.EndUpdate();
