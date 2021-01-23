        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            tabControl.TabStripPlacement = Dock.Left;
            tabControl.ItemContainerStyle = this.FindResource("Left90") as Style;
        }
        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            tabControl.TabStripPlacement = Dock.Right;
            tabControl.ItemContainerStyle = this.FindResource("Right90") as Style;
        }
