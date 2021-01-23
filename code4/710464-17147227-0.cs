    public class Item
    {
        public static ObservableCollection<OfferedConfiguration> DeviceAdjustedConfigurations
        {
            get { return deviceAdjustedConfigurations; }
            set
            {
                if (deviceAdjustedConfigurations != value)
                {
                    onDeviceConfigurationsChanging(deviceAdjustedConfigurations, value);
                    deviceAdjustedConfigurations = value;
                }
            }
        }
        public static event EventHandler<ConfigurationChangedEventArgs> DeviceConfigurationsChanging;
        private static void onDeviceConfigurationsChanging(
            ObservableCollection<OfferedConfiguration> oldList,
            ObservableCollection<OfferedConfiguration> newList)
        {
            var handler = DeviceConfigurationsChanging;
            if (handler != null)
            {
                handler(null, new ConfigurationChangedEventArgs(oldList, newList));
            }
        }
    }
    public class ConfigurationChangedEventArgs : EventArgs
    {
        public ConfigurationChangedEventArgs(
            ObservableCollection<OfferedConfiguration> oldList,
            ObservableCollection<OfferedConfiguration> newList)
        {
            OldList = oldList;
            NewList = newList;
        }
        public ObservableCollection<OfferedConfiguration> OldList { get; private set; }
        public ObservableCollection<OfferedConfiguration> NewList { get; private set; }
    }
    public class Consumer
    {
        public void foo()
        {
            Item item = new Item();
            item.DeviceConfigurationsChanging += updateEvents;
        }
        private void updateEvents(object sender, ConfigurationChangedEventArgs args)
        {
            args.OldList.CollectionChanged -= onCollectionChanged;
            args.NewList.CollectionChanged += onCollectionChanged;
        }
        private void onCollectionChanged(object sender, NotifyCollectionChangedEventArgs args) { }
    }
