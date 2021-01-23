    public class CommandDashboardViewModel
    {
        public ObservableCollection<DriverCommandViewModel> DriverCommands { get; set; }
    }
    public class DriverCommandViewModel
    {
        // all of these properties have to implement INPC
        public string CommandText { get; set; }
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
    }
