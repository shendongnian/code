    namespace LeeAlgorithm
    {
        using System.Collections.ObjectModel;
        using System.ComponentModel;
        using System.Windows;
        using System.Windows.Input;
        using System.Windows.Media;
        using System.Windows.Shapes;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                this.Cells = new ObservableCollection<Cell>();
    
                for (int i = 0; i != 50; ++i)
                {
                    this.Cells.Add(new Cell { CellNumber = i });
                }
    
                InitializeComponent();
    
                DataContext = this;
            }
    
            public ObservableCollection<Cell> Cells { get; private set; }
    
            private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
            {
                var cell = (Cell)((Rectangle)sender).Tag;
    
                if (!cell.IsSelected)
                {
                    cell.Color = new SolidColorBrush(Colors.HotPink);
                    cell.IsSelected = true;
                }
                else
                {
                    cell.Color = new SolidColorBrush(Colors.Silver);
                    cell.IsSelected = false;
                }
            }
        }
    
        public class Cell : INotifyPropertyChanged
        {
            private int cellNumber;
    
            private SolidColorBrush color = new SolidColorBrush(Colors.Silver);
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public int CellNumber
            {
                get
                {
                    return this.cellNumber;
                }
                set
                {
                    if (value == this.cellNumber)
                    {
                        return;
                    }
                    this.cellNumber = value;
                    this.OnPropertyChanged("CellNumber");
                }
            }
    
            public SolidColorBrush Color
            {
                get
                {
                    return this.color;
                }
                set
                {
                    if (Equals(value, this.color))
                    {
                        return;
                    }
                    this.color = value;
                    this.OnPropertyChanged("Color");
                }
            }
    
            public bool IsSelected { get; set; }
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
