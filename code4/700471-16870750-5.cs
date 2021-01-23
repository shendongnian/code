    public partial class App : Application
    {
        public ObservableCollection<MenuItem> ContextMenu { get; set; }
        public App()
        {
            ContextMenu = new ObservableCollection<MenuItem>();
            var mi = new MenuItem {Name = "Test"};
            ContextMenu.Add(mi);
        }
    }
