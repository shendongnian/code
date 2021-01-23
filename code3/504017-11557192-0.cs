    public interface IViewModelBase : INotifyPropertyChanged
    {
    }
    public abstract class Vm : IViewModelBase 
    {
            public string Name { get; set; }
            public int Value { get; set; }
    }
    
    public class ZoneVm : Vm
    {
        // Zone specific functionality
    }
    
    public class UserVm : Vm
    {
        // User specific functionality
    }
    
    public class PanelData : IViewModelBase
    {
        public int SerialNumber { get; set; }
        public Customer Customer { get; set; }
    }
