    yourTab.Selecting += new TabControlCancelEventHandler(tabControl_Selecting);
    void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
    {
        TabPage current = (sender as TabControl).SelectedTab;
        
        //check if current is search tab then
        {
          ScrollToTopBehavior.SetScrollToTop(yourList,true);
        }
        else
        {
          ScrollToTopBehavior.SetScrollToTop(yourList,false);
        }
    }
