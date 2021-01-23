    public class WidgetListViewModel 
    {
        public ObservableCollection<WidgetViewModel> Widgets {get; set; } 
    }
    public class WidgetViewModel
    {
        public string WidgetName { get; set; }
        public string WidgetDescription { get; set; }
        public ObservableCollection<WidgetPartViewModel> Parts { get; set; }
    }
    public class WidgetPartViewModel
    {
        public int PartId { get; set; }
        public System.Windows.Media.Color Color { get; set; }
    }
