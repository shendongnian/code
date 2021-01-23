         private void basketDG_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            DependencyObject depObj = (DependencyObject)e.OriginalSource;
            while ((depObj != null) && !(depObj is Microsoft.Windows.Controls.DataGridCell))
            {
                depObj = VisualTreeHelper.GetParent(depObj);
            }
            if (depObj == null)
            {
                return;
            }
            if (depObj is Microsoft.Windows.Controls.DataGridCell)
            {
                var obj = depObj as Microsoft.Windows.Controls.DataGridCell;
                var menu = TryFindResource("cellContextMenu") as ContextMenu;
                if (menu != null && menu.Items.Count > 0)
                {
                    var menuitem = menu.Items[0] as MenuItem;
                    if (menuitem != null)
                    {
                        var col = obj.Column.Header;
                        if(col.Equals("Column1") || col.Equals("Column1") 
                            || col.Equals("Column3") || col.Equals("Column4"))
                        {
                            menuitem.Header = "Set all to " + obj;
                            menu.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            menu.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
        } 
