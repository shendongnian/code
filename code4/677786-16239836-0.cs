    protected void PageInit(object o, EventArgs e){
        loadAndPopulateTabs();
    }
    protected void loadAndPopulateTabs()
        {
            Juice.TabPage utilityTab = new Juice.TabPage();
            utilityTab.Title = "Utilities";
            utilityTab.ID = "utTab";
    
            string utilTabText = "sometext";
            dataTabContent dtcUT = new dataTabContent(utilTabText);
    
            utilityTab.TabContent = dtcUT;
            dataTabs.TabPages.Add(utilityTab);
    }
