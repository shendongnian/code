       public partial class MainWindow : Window
        {
            private ObservableCollection<ProcessInfo> _processes = new ObservableCollection<ProcessInfo>();
    
            public MainWindow()
            {
                InitializeComponent();
                Processes.Add(new ProcessInfo
                {
                    CpuUsage = 10.3,
                    MemUsage = 48.9,
                    Processes = new ObservableCollection<Process>()
                });
                var pro = new Process{ Name = "Process1", Processes = new ObservableCollection<Process>()};
                pro.Processes.Add(new Process { Name = "SubProcess1", Processes = new ObservableCollection<Process>() });
                Processes[0].Processes.Add(pro);
                Processes.Add(new ProcessInfo
                {
                    CpuUsage = 0,
                    MemUsage = 100,
                    Processes = new ObservableCollection<Process>()
                });
                var pro2 = new Process { Name = "Process2", Processes = new ObservableCollection<Process>() };
                pro2.Processes.Add(new Process { Name = "SubProcess1", Processes = new ObservableCollection<Process>() });
                pro2.Processes.Add(new Process { Name = "SubProcess2", Processes = new ObservableCollection<Process>() });
                pro2.Processes.Add(new Process { Name = "SubProcess3", Processes = new ObservableCollection<Process>() });
                Processes[1].Processes.Add(pro2);
            }
    
            public ObservableCollection<ProcessInfo> Processes
            {
                get { return _processes; }
                set { _processes = value; }
            }
        }
    
        public class ProcessInfo
        {
            public ObservableCollection<Process> Processes { get; set; }
            public double CpuUsage { get; set; }
            public double MemUsage { get; set; }
        }
    
        public class Process
        {
            public string Name { get; set; }
            public ObservableCollection<Process> Processes { get; set; }
        }
