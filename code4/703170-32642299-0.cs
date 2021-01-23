    private void ListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        ScrollToEnd(this.lvLogs);
    }
    
    public void ScrollToEnd(ListView _ListView)
        {
            ScrollViewer _ScrollViewer = GetDescendantByType(_ListView, typeof(ScrollViewer)) as ScrollViewer;
            _ScrollViewer.ScrollToEnd();
        }
    
    public Visual GetDescendantByType(Visual element, Type type)
        {
            if (element == null) return null;
            if (element.GetType() == type) return element;
            Visual foundElement = null;
            if (element is FrameworkElement)
            {
                (element as FrameworkElement).ApplyTemplate();
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }
