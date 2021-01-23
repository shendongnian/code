    namespace Example
    {
        using System.Collections.ObjectModel;
        using System.Windows.Controls;
    
        class MainWindowViewModel
        {
            public ObservableCollection<string> Entries { get; set; }
    
            public MainWindowViewModel()
            {
                List<string> list = new List<string>() { "Entry 1", "Entry 2", "Entry 3" };
                Entries = new ObservableCollection<string>(list);
            }
        }
    }
