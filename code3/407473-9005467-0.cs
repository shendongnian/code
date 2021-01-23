    TabPanel FirstTab= new TabPanel();  
    FirstTab.ID = "Tab1";  
    FirstTab.HeaderText = "First Tab";  
    
    TabPanel SecondTab = new TabPanel();  
    SecondTab.ID = "Tab2";  
    SecondTab.HeaderText = "Second Tab";  
    
    TabContainer1.Tabs.Add(FirstTab);  //add it to the Tab Container control 
    TabContainer1.Tabs.Add(SecondTab);  
    
    TabContainer1.ActiveTabIndex = 0;  // set your active tab index to display. 
