    yourTab.SelecnionChanged+= new TabControlCancelEventHandler(tabControl_Selecting);
    void tabControl_SelecnionChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var current = (sender as TabControl).SelectedValue;
        
        //check if current is search tab then
        {
          ScrollToTopBehavior.SetScrollToTop(yourList,true);
        }
        else
        {
          ScrollToTopBehavior.SetScrollToTop(yourList,false);
        }
    }
