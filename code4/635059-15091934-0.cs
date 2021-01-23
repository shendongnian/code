    private object GetDataFromListBox(ListBox source, Point point)
        {
            DependencyObject element = source.InputHitTest(point) as DependencyObject;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = (DependencyObject)VisualTreeHelper.GetParent(element);
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }
        private void lstCameras_PreviewMouseMove_1(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed && this.DataContext != null &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListBox parent = (ListBox)sender;
                Item data = (Item)GetDataFromListBox(parent, e.GetPosition(parent));
                if (data != null)
                {
                    DataObject dragData = new DataObject(typeof(Item), data);
                    DragDrop.DoDragDrop(this, dragData, DragDropEffects.All);
                }
            }
        }
        private void lstCameras_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            Item data = (Item)GetDataFromListBox(parent, e.GetPosition(parent));
            
            if (data != null )
            {
                startPoint = e.GetPosition(null);
                e.Handled = true;
            }
        }
        private void lstCameras_PreviewMouseUp_1(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            Item data = (Item)GetDataFromListBox(parent, e.GetPosition(parent));
            if (data != null)
            {
                lstCameras.SelectedItem = data;
            }
        }
