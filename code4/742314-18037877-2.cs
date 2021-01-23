    public partial class Horses : UserControl, INotifyPropertyChanged
    {
        public enum CapPattern { ChevronPattern, SomeOtherPattern };
        public Dictionary<CapPattern, Geometry> Patterns { get; set; }
        private Geometry currentPath;
        public Geometry CurrentPath
        {
            get { return this.currentPath; }
            set 
            { 
                this.currentPath = value;
                NotifyPropertyChanged();
            }
        }
        public Horses()
        {
            Patterns = new Dictionary<CapPattern, Geometry>();          
            
            Patterns.Add(
                CapPattern.ChevronPattern,
                Geometry.Combine(
                    Geometry.Parse("M21.750001,94.749999 L34.000002,117.66218 30.625003,133.62501 17.000006,113.32909 0.5,126.75 3.2500048,108.125 z M212.418,93.416999 L230.918,106.79199 233.668,125.41701 217.168,111.99609 203.543,132.292 200.168,116.32917 z M32.25,48.374999 L44.250004,72.249999 40.625004,90.249999 28.000003,68.581336 7.750001,82.249999 11.665709,64.166339 z M201.918,47.041991 L222.50229,62.833335 226.418,80.916991 206.168,67.248336 193.543,88.916999 189.918,70.916991 z M41,1.8329993 L55.000002,28.166337 51.66667,45.832999 37.333336,23.499837 16.666001,37.417269 21.66571,19.418135 z M193.168,0.5 L212.50229,18.085143 217.502,36.084262 196.83467,22.166836 182.50133,44.499991 179.168,26.833333 z"),
                    Geometry.Empty, 
                    GeometryCombineMode.Union, 
                    new TranslateTransform(0, 0)));
            Patterns.Add(
                CapPattern.SomeOtherPattern, 
                Geometry.Combine(
                    Geometry.Parse("M21.750001,94.749999 L34.000002,117.66218 30.625003,133.62501 17.000006,113.32909 0.5,126.75 3.2500048,108.125 z M212.418,93.416999 L230.918,106.79199 233.668,125.41701 217.168,111.99609 203.543,132.292 200.168,116.32917 z M32.25,48.374999 L44.250004,72.249999 40.625004,90.249999 28.000003,68.581336 7.750001,82.249999 11.665709,64.166339 z M201.918,47.041991 L222.50229,62.833335 226.418,80.916991 206.168,67.248336 193.543,88.916999 189.918,70.916991 z M41,1.8329993 L55.000002,28.166337 51.66667,45.832999 37.333336,23.499837 16.666001,37.417269 21.66571,19.418135 z M193.168,0.5 L212.50229,18.085143 217.502,36.084262 196.83467,22.166836 182.50133,44.499991 179.168,26.833333 z"), 
                    Geometry.Empty, 
                    GeometryCombineMode.Union, 
                    new TranslateTransform(20, 30)));           
            
            InitializeComponent();
        }
        // INotifyPropertyChanged implementaton.
    }
