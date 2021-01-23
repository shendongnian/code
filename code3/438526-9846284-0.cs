    interface IReportParams
    {
        IEnumerable<Guid> SelectedItems { get; }
        IEnumerable<StatusEnum> SelectedStatuses { get; }
    }
    
    class MvcReportParams : IReportParams
    {
        public MvcReportParams()
        {
            SelectedItems = new Collection<Guid>();
            SelectedStatuses = new Collection<StatusEnum>();
        }
    
        public IEnumerable<Guid> SelectedItems { get; private set; }
        public IEnumerable<StatusEnum> SelectedStatuses { get; private set; }
    }
    
    class WpfReportParams : IReportParams
    {
        public WpfReportParams()
        {
            SelectedItems = new ObservableCollection<Guid>();
            SelectedStatuses = new ObservableCollection<StatusEnum>();
        }
    
        public IEnumerable<Guid> SelectedItems { get; private set; }
        public IEnumerable<StatusEnum> SelectedStatuses { get; private set; }
    }
