    public partial class MainWindow : Window
    {
    	const int LinePointsCount = 128;
    	const int LinesCount = 20;
    	const int TimerIntervalInMilliseconds = 1000;
    
    	private static DateTime Current = DateTime.Now;
    	Random _random = new Random();
    	List<string> _chartNames;
    
    	public MainWindow()
    	{
    		InitializeComponent();
    
    		_chartNames = Enumerable.Repeat(1, LinesCount).Select((con, index) => index.ToString()).ToList();
    	}
    
    	Timer _timer;
    
    	private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    	{
    		_timer = new Timer((o) => Dispatcher.Invoke(new Action(ShowData)));
    		_timer.Change(0, TimerIntervalInMilliseconds);
    	}
    
    	private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    	{
    
    	}
    
    	private void ShowData()
    	{
    		var data = GetData();
    		foreach (KeyValuePair<string, List<RamPlot>> kvp in data)
    		{
    			bool exists = false;
    			foreach (LineSeries series in chart.Series)
    			{
    				if (series.Title.ToString().Equals(kvp.Key) && !string.IsNullOrEmpty(kvp.Key))
    				{
    					series.ItemsSource = null;
    					series.ItemsSource = kvp.Value;
    					exists = true;
    					break;
    				}
    			}
    			if (!exists && !string.IsNullOrEmpty(kvp.Key))
    			{
    				LineSeries series = new LineSeries();
    				series.Title = kvp.Key;
    				series.IndependentValueBinding = new Binding("Date");
    				series.DependentValueBinding = new Binding("Usage");
    				series.ItemsSource = kvp.Value;
    				chart.Series.Add(series);
    			}
    		}
    	}
    
    	Dictionary<string, List<RamPlot>> GetData()
    	{
    		var result = new Dictionary<string, List<RamPlot>>();
    
    		var chartName = GetRandomChartName();
    
    		result.Add(chartName, new List<RamPlot>
    			{
    				new RamPlot{Date = Current, Usage = 100},
    				new RamPlot{Date = Current.AddDays(-LinePointsCount), Usage = 300},
    			});
    
    
    		var random = _random.Next(101, 300);
    		for (int i = 1; i < LinePointsCount; i++)
    		{
    			var newElement = new RamPlot { Date = Current.AddDays(-i), Usage = random };
    			result[chartName].Add(newElement);
    		}
    
    		return result;
    	}
    
    	string GetRandomChartName()
    	{
    		var nextIndex = _random.Next(0, _chartNames.Count);
    		return _chartNames[nextIndex];
    	}
    }
    public class RamPlot
    {
    	public DateTime Date { get; set; }
    
    	public int Usage { get; set; }
    }
