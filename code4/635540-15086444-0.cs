    protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            base.OnViewLoaded(sender, e);
            list = VisualTreeUtil.FindFirstInTree<ListView>(Application.Current.MainWindow, "ListView");
            ConfigureAndSuperviseInputControls(this.list);
            ScrollViewer scroll = VisualTreeUtil.FindFirstInTree<ScrollViewer>(this.list);
            scroll.ScrollChanged+=new ScrollChangedEventHandler(scroll_ScrollChanged);       
        }
    
      void scroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {  
            ConfigureAndSuperviseInputControls(this.list);
            ScrollViewer sb = sender as ScrollViewer;
            if (sb.ContentVerticalOffset==sb.ScrollableHeight)
            {
               scroll.ScrollChanged-=new ScrollChangedEventHandler(scroll_ScrollChanged); 
            }
        }
