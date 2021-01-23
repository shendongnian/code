            readonly List<string> shownTabs;
    
            public MainWindow()
            {
                InitializeComponent();
                this.shownTabs = new List<string>();
                this.tabCtrl.SelectionChanged += tabCtrl_SelectionChanged;
            }
    
            void tabCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if(e.AddedItems.Count == 0)
                    return;
                var tabItem = e.AddedItems[0] as TabItem;
                if (tabItem == null)
                    return;
                if(this.shownTabs.Contains(tabItem.Name))
                    return;
                this.shownTabs.Add(tabItem.Name);
    
                if (tabItem == this.tab1)
                {
                    //TODO : tab 1 logic
                }
                else if (tabItem == this.tab2)
                {
                    //TODO : tab 2 logic
                }
            }
