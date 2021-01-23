    public partial class MainWindow : Window
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private Task _makeCallsTask;
        public MainWindow()
        {
            Calls = new ObservableCollection<string>();
            _cancellationTokenSource = new CancellationTokenSource();
            InitializeComponent();
            this.DataContext = Calls;
        }
    
        public ObservableCollection<string> Calls { get; set; }
    
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (_makeCallsTask == null)
            {
                _makeCallsTask = Task.Factory.StartNew(MakeCall, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
            }
            else
            {
                _cancellationTokenSource.Cancel();
                _makeCallsTask = null;
                Calls.Clear();
            }
        }
    
        private void MakeCall()
        {
            int i = 0;
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                Thread.Sleep(1000);
                this.Dispatcher.Invoke(new Action(() => Calls.Add("Called " + i)));
                i++;
            }
        }
    }
    <Window x:Class="TaskSample.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="262*" />
                <RowDefinition Height="49*" />
            </Grid.RowDefinitions>
            <ListBox ItemsSource="{Binding}"/>
            <StackPanel Grid.Row="1">
                <ToggleButton   Click="ButtonClick">
                    <ToggleButton.Style>
                        <Style TargetType="{x:Type ToggleButton}">
                            <Setter Property="Content" Value="Start"/>
                            <Style.Triggers>
                                <Trigger Property="IsChecked" Value="True">
                                    <Setter Property="Content" Value="Cancel"/>
                                </Trigger>
                            </Style.Triggers>
                        </Style>
                    </ToggleButton.Style>
                </ToggleButton>
            </StackPanel>
        </Grid>
    </Window>
