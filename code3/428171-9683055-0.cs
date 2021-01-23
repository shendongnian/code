      private void dtgExtended_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is Control
                && (!e.OriginalSource.ToString().Equals("Microsoft.Windows.Themes.ScrollChrome") && !e.OriginalSource.ToString().Equals("System.Windows.Shapes.Rectangle")))
            {
                e.Handled = false;
                DataGridDoubleClick c = new DataGridDoubleClick();
            }
            else
                e.Handled = true;
        }
