    public partial class MultiToolbar : Window
        {
            public MultiToolbar()
            {
                InitializeComponent();
    
                var vm = new MainViewModel();
                vm.Sections.Add(new FileSection() {Name = "File"});
                vm.Sections.Add(new NetworkDesignSection() { Name = "Network Design" });
                vm.Sections.Add(new SelectAnalysisSection() { Name = "Select Analysis" });
    
                DataContext = vm;
            }
        }
