     private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (e.OriginalSource is TabControl)
                {
                    if (tabControl1.SelectedIndex == 0)
                    {
                        // Do something               
                    }
                    else if (tabControl1.SelectedIndex == 1)
                    {  
                        DashboardFilterView filterWindow = new DashboardFilterView();
                        filterWindow.ShowDialog();         
                    }
                }
    
            }
