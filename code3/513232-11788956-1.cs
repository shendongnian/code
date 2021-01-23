        CollectionViewSource viewSource_dataLinesUnfiltered;
        CollectionViewSource viewSource_dataLinesFiltered;
        ...
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = dataLines;
            viewSource_dataLinesUnfiltered = (CollectionViewSource)this.Resources["viewSource_dataLinesUnfiltered"];
            viewSource_dataLinesUnfiltered.Source = dataLines;
            viewSource_dataLinesFiltered = (CollectionViewSource)this.Resources["viewSource_dataLinesFiltered"];
            viewSource_dataLinesFiltered.Source = dataLines;
            // Control Events
            this.ShowAA.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ToggleButton.UncheckedEvent));
        }
        private void ShowAA_Checked(object sender, RoutedEventArgs e)
        {
            viewSource_dataLinesUnfiltered.View.Filter = null;
        }
        private void ShowAA_UnChecked(object sender, RoutedEventArgs e)
        {
            viewSource_dataLinesUnfiltered.View.Filter = delegate(object o) { return FilterContent(o as ErrorDetection.stDataLine, "AA", ""); };
        }
        bool FilterContent(ErrorDetection.stDataLine line, string sFilterAA, string sFilter)
        {
            shortArrayToHexStringConverter converter = new shortArrayToHexStringConverter();
            string comBuffer = converter.Convert(line.ComBufferP as object,typeof(string),0,System.Globalization.CultureInfo.CurrentCulture) as string;
            return !comBuffer.Contains("AA");
        }
