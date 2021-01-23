     void mainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabItem)
            {       
                if (this.IsLoaded)
                {
                    //do work when tab is changed
                }
            }
        }
