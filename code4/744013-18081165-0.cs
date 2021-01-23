    private void StationsListLB_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var item = ItemsControl.ContainerFromElement(StationsListLB, e.OriginalSource as DependencyObject) as ListBoxItem;
        if (item != null)
        {
            var opa = e.OriginalSource as System.Windows.Controls.Image;
            MessageBox.Show(opa.Tag.ToString());
        }
    }
