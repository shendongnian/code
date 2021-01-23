    <Page.Resources>
        <ViewModel:ReactiveListViewModel x:Key="model"/>
    </Page.Resources>
    
    <Grid DataContext="{StaticResource model}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Button Content="Start" Command="{Binding StartCommand}"/>
        <ListBox ItemsSource="{Binding Items}" Grid.Row="1"/>
    </Grid>
    public class ReactiveListViewModel : ViewModelBase
    {
        public ReactiveListViewModel()
        {
            Items = new ObservableCollection<long>();
            StartCommand = new RelayCommand(Start);
        }
        public ICommand StartCommand { get; private set; }
        private void Start()
        {
            var observable = Observable.Interval(TimeSpan.FromSeconds(1));
            //Exception: This type of CollectionView does not support changes to its SourceCollection from a thread different from the Dispatcher thread.
            //observable.Subscribe(num => Items.Add(num));
            // Works fine
            observable.ObserveOn(SynchronizationContext.Current).Subscribe(num => Items.Add(num));
            // Works fine
            //observable.ObserveOnDispatcher().Subscribe(num => Items.Add(num));
        }
        public ObservableCollection<long> Items { get; private set; }
    }
