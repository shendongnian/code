    <Window x:Class="CameraSelection.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
            xmlns:MyNamespace="clr-namespace:CameraSelection"
            Title="MainWindow" Height="350" Width="525">    
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="150" />
                <ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>        
            <TextBlock Grid.Row="0" Grid.Column="0" HorizontalAlignment="Right" VerticalAlignment="Center">Camera</TextBlock>
            <!-- 
            bind the source to MainWindow.Cameras; 
            set value onto MainWindow.Camera; 
            set the display member;
            auto-select first entry 
            -->
            <ComboBox Name="comboCameras" Grid.Row="0" Grid.Column="1" Margin="5" 
                      SelectedItem="{Binding Path=Camera, RelativeSource={RelativeSource AncestorType=MyNamespace:MainWindow}}" 
                      ItemsSource="{Binding Path=Cameras, RelativeSource={RelativeSource AncestorType=MyNamespace:MainWindow}}"
                      DisplayMemberPath="Name" 
                      SelectedIndex="0"
                      />
            <TextBlock Grid.Row="1" Grid.Column="0" HorizontalAlignment="Right" VerticalAlignment="Center">Resolution</TextBlock>
            <!-- 
            bind the source to MainWindow.Resolutions; 
            set value onto MainWindow.Resolution;
            auto-select first entry;
            reload data according to MainWindow.PropertyChanged
            -->
            <ComboBox Name="comboResolutions" Grid.Row="1" Grid.Column="1" Margin="5" 
                      SelectedItem="{Binding Path=Resolution, RelativeSource={RelativeSource AncestorType=MyNamespace:MainWindow}}" 
                      ItemsSource="{Binding Path=Resolutions, UpdateSourceTrigger=PropertyChanged, RelativeSource={RelativeSource AncestorType=MyNamespace:MainWindow}}" 
                      SelectedIndex="0"
                      />
        </Grid>
    </Window>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Camera camera;
        #region Setters for SelectedItem
        public Camera Camera 
        {
            get { return camera; }
            set
            {
                if (value == camera)
                    return;
                camera = value;
                OnPropertyChanged("Camera");            // camera has changed
                OnPropertyChanged("Resolutions");       // available resolution might have changed too
            }
        }
        public Size Resolution
        {
            get;
            set;
        }
        #endregion
        #region ItemSources
        public IEnumerable<Camera> Cameras
        {
            get
            {
                yield return new Camera { Name = "Integrated Webcam", Resolutions = new[] { new Size(800,600), new Size(640,480) } };
                yield return new Camera { Name = "USB Webcam", Resolutions = new[] { new Size(1024, 768), new Size(800, 600) } };
            }
        }
        public IEnumerable<Size> Resolutions
        {
            get
            {
                if (Camera == null)
                    yield break;
                foreach (Size resolution in camera.Resolutions)
                    yield return resolution;
            }
        }
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class Camera
    {
        public string Name { get; set; }
        public IEnumerable<Size> Resolutions 
        {
            get; set;
        }
    }
