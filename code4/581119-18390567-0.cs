        private static void OnPreviewListBoxMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var listBox = sender as Selector;
            if (listBox != null)
            {
                DependencyObject mouseItem = e.OriginalSource as DependencyObject;
                if (mouseItem != null)
                {
                    // Get the container based on the element
                    var container = listBox.ContainerFromElement(mouseItem);
                    if (container != null)
                    {
                        var index = listBox.ItemContainerGenerator.IndexFromContainer(container);
                        Debug.Assert(index >= 0);
                        listBox.SelectedIndex = index;
                    }
                }
            }
        }
