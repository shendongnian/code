    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new UnityContainer();
            container.RegisterType<IMainView, MainWindow>();
            container.RegisterType<ISecondView, SecondWindow>();
            container.RegisterType<IMainPresenter, MainPresenter>();
            container.RegisterType<ISecondPresenter, SecondPresenter>();
            var presenter = container.Resolve<IMainPresenter>();
            presenter.ShowView();
        }
    }
    public interface IMainPresenter
    {
        void ShowView();
        void OpenSecondView();
    }
    public interface ISecondPresenter
    {
        void ShowView();
    }
    public interface ISecondView
    {
        void Show();
        SecondViewModel ViewModel { get; set; }
    }
    public interface IMainView
    {
        void Show();
        MainViewModel ViewModel { get; set; }
    }
    public class MainPresenter : IMainPresenter
    {
        private readonly IMainView _mainView;
        private readonly ISecondPresenter _secondPresenter;
        public MainPresenter(IMainView mainView, ISecondPresenter secondPresenter)
        {
            _mainView = mainView;
            _secondPresenter = secondPresenter;
        }
        public void ShowView()
        {
            // Could be resolved through Unity just as well
            _mainView.ViewModel = new MainViewModel(this);
            _mainView.Show();
        }
        public void OpenSecondView()
        {
            _secondPresenter.ShowView();
        }
    }
    public class SecondPresenter : ISecondPresenter
    {
        private readonly ISecondView _secondView;
        public SecondPresenter(ISecondView secondView)
        {
            _secondView = secondView;
        }
        public void ShowView()
        {
            // Could be resolved through Unity just as well
            _secondView.ViewModel = new SecondViewModel();
            _secondView.Show();
        }
    }
    public class MainViewModel
    {
        public MainViewModel(MainPresenter mainPresenter)
        {
            OpenSecondViewCommand = new DelegateCommand(mainPresenter.OpenSecondView);
        }
        public DelegateCommand OpenSecondViewCommand { get; set; }
    }
    public class SecondViewModel
    {
    }
    <!-- MainWindow.xaml -->
    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Button Command="{Binding OpenSecondViewCommand}" Content="Open second view" />
        </Grid>
    </Window>
    <!-- SecondWindow.xaml -->
    <Window x:Class="WpfApplication1.SecondWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="SecondWindow" Height="350" Width="525">
        <Grid>
            <TextBlock>Second view</TextBlock>
        </Grid>
    </Window>
