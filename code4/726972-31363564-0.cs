        private static DependencyObject GetNextSiblingInVisualTree(DependencyObject origin)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(origin);
            if (parent != null)
            {
                int childIndex = -1;
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); ++i)
                {
                    if (origin == VisualTreeHelper.GetChild(parent, i))
                    {
                        childIndex = i;
                        break;
                    }
                }
                for (int nextIndex = childIndex + 1; nextIndex < VisualTreeHelper.GetChildrenCount(parent); nextIndex++ )
                {
                    DependencyObject currentObject = VisualTreeHelper.GetChild(parent, nextIndex);
                    if( currentObject.GetType() == typeof(TextBox))
                    {
                        return currentObject;
                    }
                }
            }
            return null;
        }
