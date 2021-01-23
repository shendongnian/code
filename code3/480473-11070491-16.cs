    public class MapFixBehavior
    {
        public static DependencyProperty FixUpdateProperty =
            DependencyProperty.RegisterAttached("FixUpdate",
                                                typeof(bool),
                                                typeof(MapFixBehavior),
                                                new FrameworkPropertyMetadata(false,
                                                                              OnFixUpdateChanged));
        public static bool GetFixUpdate(DependencyObject mapItemsControl)
        {
            return (bool)mapItemsControl.GetValue(FixUpdateProperty);
        }
        public static void SetFixUpdate(DependencyObject mapItemsControl, bool value)
        {
            mapItemsControl.SetValue(FixUpdateProperty, value);
        }
        private static void OnFixUpdateChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            MapItemsControl mapItemsControl = target as MapItemsControl;
            ItemsChangedEventHandler itemsChangedEventHandler = null;
            itemsChangedEventHandler = (object sender, ItemsChangedEventArgs ea) =>
            {
                if (ea.Action == NotifyCollectionChangedAction.Add)
                {
                    EventHandler statusChanged = null;
                    statusChanged = new EventHandler(delegate
                    {
                        if (mapItemsControl.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                        {
                            mapItemsControl.ItemContainerGenerator.StatusChanged -= statusChanged;
                            int index = ea.Position.Index + ea.Position.Offset;
                            ContentPresenter contentPresenter =
                                mapItemsControl.ItemContainerGenerator.ContainerFromIndex(index) as ContentPresenter;
                            if (VisualTreeHelper.GetChildrenCount(contentPresenter) == 1)
                            {
                                MapLayer mapLayer = GetVisualParent<MapLayer>(mapItemsControl);
                                mapLayer.ForceMeasure();
                            }
                            else
                            {
                                EventHandler layoutUpdated = null;
                                layoutUpdated = new EventHandler(delegate
                                {
                                    if (VisualTreeHelper.GetChildrenCount(contentPresenter) == 1)
                                    {
                                        contentPresenter.LayoutUpdated -= layoutUpdated;
                                        MapLayer mapLayer = GetVisualParent<MapLayer>(mapItemsControl);
                                        mapLayer.ForceMeasure();
                                    }
                                });
                                contentPresenter.LayoutUpdated += layoutUpdated;
                            }
                        }
                    });
                    mapItemsControl.ItemContainerGenerator.StatusChanged += statusChanged;
                }
            };
            mapItemsControl.ItemContainerGenerator.ItemsChanged += itemsChangedEventHandler;
        }
        private static T GetVisualParent<T>(object childObject) where T : Visual
        {
            DependencyObject child = childObject as DependencyObject;
            while ((child != null) && !(child is T))
            {
                child = VisualTreeHelper.GetParent(child);
            }
            return child as T;
        }
    }
