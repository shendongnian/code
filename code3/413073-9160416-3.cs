    using System.Collections.ObjectModel;
    using System.Windows;
    namespace ComboBoxSample
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AxisBases = new ObservableCollection<AxisBase>
                            {
                                new AxisBase {Name = "Firts"},
                                new AxisBase {Name = "Second"},
                                new AxisBase {Name = "Third"}
                            };
            //Set the data context for use binding
            DataContext = this;
        }
        public ObservableCollection<AxisBase> AxisBases { get; set; }
    }
    public class AxisBase
    {
        public string Name { get; set; }
    }
