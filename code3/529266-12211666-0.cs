        e.OrginalSource
---------------------------
        private void treeView1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = GetSexyGrandDaddy(e.Source as DependencyObject);
            if (treeViewItem != null)
            {
                //do highlight...
            }
        }
        private static TreeViewItem GetSexyGrandDaddy(DependencyObject source)
        {
            TreeViewItem sugarDad = source as TreeViewItem;
            if (sugarDad != null)
            {
                while (sugarDad.Parent as TreeViewItem != null)
                    sugarDad = sugarDad.Parent as TreeViewItem;
            }
            return sugarDad;
        }
