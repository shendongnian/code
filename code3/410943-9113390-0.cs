    newFrame = new Frame();
    newFrame.Navigate(new LoginPage(this));
    newFrame.IsTabStop = false;
    tabItem = new TabItem();
    tabItem.Header = "Login";
    tabItem.Content = newFrame;
    wizardTabs.Items.Add(tabItem);
