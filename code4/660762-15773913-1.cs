    public partial class WrongCode : Window
        {
            public ObservableCollection<LineModel> Lines { get; set; }
    
            public WrongCode()
            {
                InitializeComponent();
                Lines = new ObservableCollection<LineModel>();
                DataContext = Lines;
            }
    
            private void Sort(object sender, RoutedEventArgs e)
            {
                SortTimer = new Timer(x => SortItem(), null, 0, 100);
            }
    
            private void SortItem()
            {
                //Implement your sort algorithm here by
                //Modifying the ObservableCollection in this way:
                //Lines.Move(index1, index2);
    
                //This example is just moving the lines randomly without any sort order
                var index1 = rnd.Next(0, Lines.Count - 1);
                var index2 = rnd.Next(0, Lines.Count - 1);
    
                Dispatcher.BeginInvoke((Action) (() => Lines.Move(index1, index2)));
            }
    
            public static System.Threading.Timer SortTimer;
            public static Random rnd = new Random();
    
            private void Shuffle(object sender, RoutedEventArgs e)
            {
                if (SortTimer != null)
                    SortTimer.Dispose();
    
                Lines.Clear();
    
                Enumerable.Range(0, rnd.Next(50, 60))
                          .Select(x => new LineModel()
                              {
                                  Length = rnd.Next(1, 100)
                              })
                          .ToList()
                          .ForEach(Lines.Add);
    
            }
        }
    
        public class LineModel
        {
            public int Length { get; set; }
        }
