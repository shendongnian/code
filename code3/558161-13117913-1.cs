    public class ViewModel : INotifyPropertyChanged 
        {
            private readonly IReportService _reportService;
            private ObservableCollection<ReportViewModel> _reports = new ObservableCollection<ReportViewModel>();
            private PerformanceViewModel _currentPerformance;
            private ReportViewModel _currentReport;
    
            public ObservableCollection<ReportViewModel> Reports
            {
                get { return _reports; }
                set { _reports = value; OnPropertyChanged("Reports");}
            }
    
            public ReportViewModel CurrentReport
            {
                get { return _currentReport; }
                set { _currentReport = value; OnPropertyChanged("CurrentReport");}
            }
    
            public PerformanceViewModel CurrentPerformance
            {
                get { return _currentPerformance; }
                set { _currentPerformance = value; OnPropertyChanged("CurrentPerformance");}
            }
    
            public ICollectionView ReportsView { get; private set; }
            public ICollectionView PerformancesView { get; private set; }        
            
            public ViewModel(IReportService reportService)
            {
                if (reportService == null) throw new ArgumentNullException("reportService");
                _reportService = reportService;
                
                var reports = _reportService.GetData();
                Reports = new ObservableCollection<ReportViewModel>(reports);
    
                ReportsView = CollectionViewSource.GetDefaultView(Reports);
                ReportsView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                ReportsView.CurrentChanged += OnReportsChanged;
                ReportsView.MoveCurrentToFirst();
            }
    
            private void OnReportsChanged(object sender, EventArgs e)
            {
                var selectedReport = ReportsView.CurrentItem as ReportViewModel;
                if (selectedReport == null) return;
    
                CurrentReport = selectedReport;
    
                if(PerformancesView != null)
                {
                    PerformancesView.CurrentChanged -= OnPerformancesChanged;
                }
    
                PerformancesView = CollectionViewSource.GetDefaultView(CurrentReport.Performances);
                PerformancesView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                PerformancesView.CurrentChanged += OnPerformancesChanged;
                PerformancesView.MoveCurrentToFirst();
            }
    
            private void OnPerformancesChanged(object sender, EventArgs e)
            {
                var selectedperformance = PerformancesView.CurrentItem as PerformanceViewModel;
                if (selectedperformance == null) return;
    
                CurrentPerformance = selectedperformance;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
