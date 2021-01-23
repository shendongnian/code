    ((INotifyCollectionChanged)lvLogs.Items).CollectionChanged += ListView_CollectionChanged;
    private void ListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        ScrollToEnd(this.lvLogs);
    }
    private void ListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if ((e.Action == NotifyCollectionChangedAction.Add) && (e.NewItems != null))
                {
                    try 
                    {
                        ScrollToEnd(this.lvLogs);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error updating list view", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
        
                }
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
