      private void FindElement(object sender, RoutedEventArgs e)
     
        {
 
            // get the current selected item
 
            ListViewItem item = listview.ItemContainerGenerator.ContainerFromIndex(listview.SelectedIndex) as ListViewItem;
 
            TextBlock textYear = null;
 
            if (item != null)
 
            {
 
                //get the item's template parent
 
                ContentPresenter templateParent = GetFrameworkElementByName<ContentPresenter>(item);
 
                //get the DataTemplate that TextBlock in.
 
                DataTemplate dataTemplate = listview.ItemTemplate;
 
                if (dataTemplate != null && templateParent != null)
 
                {
 
                     textYear = dataTemplate.FindName("textYear", templateParent) as TextBlock;
 
                }
 
                if (textYear != null)
 
                {
 
                    MessageBox.Show(String.Format("Current item's Year is:{0}", textYear.Text));
 
                }
 
            }
 
 
 
        }
 
        private static T GetFrameworkElementByName<T>(FrameworkElement referenceElement) where T : FrameworkElement
 
        {
 
            FrameworkElement child = null;
 
            for (Int32 i = 0; i < VisualTreeHelper.GetChildrenCount(referenceElement); i++)
 
            {
 
                child = VisualTreeHelper.GetChild(referenceElement, i) as FrameworkElement;
 
                System.Diagnostics.Debug.WriteLine(child);
 
                if (child != null && child.GetType() == typeof(T))
 
                { break; }
 
                else if (child != null)
 
                {
 
                    child = GetFrameworkElementByName<T>(child);
 
                    if (child != null && child.GetType() == typeof(T))
 
                    {
 
                        break;
 
                    }
 
                }
 
            }
 
            return child as T;
 
        }
