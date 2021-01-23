        ScrollViewer mainScrollViewer = GetVisualChild<ScrollViewer>(yourListBoxControl);
        // ...then use the code above
        public T GetVisualChild<T>(UIElement parent) where T : UIElement
        {
            T child = null; // default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                UIElement element = (UIElement)VisualTreeHelper.GetChild(parent, i);
                child = element as T;
                if (child == null)
                    child = GetVisualChild<T>(element);
                if (child != null)
                    break;
            }
            return child;
        }
