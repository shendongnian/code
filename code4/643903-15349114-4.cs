    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<MyRunModel> _myRuns = new ObservableCollection<MyRunModel>();
        public ObservableCollection<MyRunModel> MyRuns { get { return _myRuns; } set { _myRuns = value; OnPropertyChanged("MyRuns"); } }
        public ViewModel()
        {
            List<MyRunModel> runs = new List<MyRunModel>();
            runs.Add(new MyRunModel() { Text = "Meine sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr lange run1" });
            runs.Add(new MyRunModel() { Text = "Meine run2", Foreground = ForegroundDescription.HighlightDark });
            runs.Add(new MyRunModel() { Text = "Meine sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr lange run3" });
            runs.Add(new MyRunModel() { Text = "Meine run4", Foreground = ForegroundDescription.HighlightLight, Background = BackgroundDescription.Highlight });
            runs.Add(new MyRunModel() { Text = "Meine sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr lange run5" });
            CommitMyRuns(runs);
        }
        /// <summary>
        /// Splits up every word (delimited by space), and adds the parts 
        /// to the collection that can be bound to the UI. Retains formatting information.
        /// </summary>
        /// <param name="runs"></param>
        private void CommitMyRuns(List<MyRunModel> runs)
        {
            int runCount = runs.Count;
            for (int i = 0; i < runCount; i++)
            {
                string[] parts = runs[i].Text.Split(' ');
                int partCount = parts.Length;
                for (int j = 0; j < partCount; j++)
                {
                    bool isLast = j == parts.Length - 1;
                    MyRunModel run = new MyRunModel()
                    {
                        Text = parts[j] + (isLast ? string.Empty : " "),  // add space that was lost in split
                        Foreground = runs[i].Foreground, // keep formatting
                        Background = runs[i].Background
                    };
                    MyRuns.Add(run);
                }
                MyRuns.Add(new MyRunModel() { Text = " " }); // add a space after each of the original runs (unformatted)
            }
        }
    }
    public class MyRunModel
    {
        public string Text { get; set; }
        // do not use UI types (e.g. Brush) directly in viewmodel
        public ForegroundDescription Foreground { get; set; }
        public BackgroundDescription Background { get; set; }
    }
    public enum ForegroundDescription
    {
        None = 0,
        HighlightDark,
        HighlightLight
    }
    public enum BackgroundDescription
    {
        None = 0,
        Highlight
    }
