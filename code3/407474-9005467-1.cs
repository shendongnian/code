    TabPanel FirstTab= new TabPanel();  
    FirstTab.ID = "Tab1";  
    FirstTab.HeaderText = "First Tab";  
    
    TabPanel SecondTab = new TabPanel();  
    SecondTab.ID = "Tab2";  
    SecondTab.HeaderText = "Second Tab";  
    
    TabContainer1.Tabs.Add(FirstTab);  //add it to the Tab Container control 
    TabContainer1.Tabs.Add(SecondTab);  
    
    //to added content on it you can do like this 
    Image _image = new Image();
    _image.ID = "image";
    _image.ImageUrl = "~/images/test.gif";
    FirstTab.Controls.Add(image);
    TabContainer1.ActiveTabIndex = 0;  // set your active tab index to display. 
