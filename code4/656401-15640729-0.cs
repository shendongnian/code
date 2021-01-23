    public class MyTreeViewItem : TreeViewItem
    {
            public static readonly RoutedEvent CollapsingEvent =
            EventManager.RegisterRoutedEvent("Collapsing",
                 RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                 typeof(MyTreeViewItem));
     
        public static readonly RoutedEvent ExpandingEvent =
                 EventManager.RegisterRoutedEvent("Expanding",
                 RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                 typeof(MyTreeViewItem));
     
        public event RoutedEventHandler Collapsing
        {
            add { AddHandler(CollapsingEvent, value); }
            remove { RemoveHandler(CollapsingEvent, value); }
        }
     
        public event RoutedEventHandler Expanding
        {
            add { AddHandler(ExpandingEvent, value); }
            remove { RemoveHandler(ExpandingEvent, value); }
        }
     
        protected override void OnExpanded(RoutedEventArgs e)
        {
            OnExpanding(new RoutedEventArgs(ExpandingEvent, this));
            base.OnExpanded(e);
        }
     
        protected override void OnCollapsed(RoutedEventArgs e)
        {
            OnCollapsing(new RoutedEventArgs(CollapsingEvent, this));
            base.OnCollapsed(e);
        }
     
        protected virtual void OnCollapsing(RoutedEventArgs e) { RaiseEvent(e); }
        protected virtual void OnExpanding(RoutedEventArgs e) { RaiseEvent(e); }
    }
