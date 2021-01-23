    public class ViewModel: INotifyPropertyChanged
    {
        private bool _test;
        public bool Test
        {  get { return _test; }
           set
           {
               _test = value;
               NotifyPropertyChanged("Test");
           }
        }
    
        public PropertyChangedEventHandler PropertyChanged;
    
        public void NotifyPropertyChanged(string propertyName)
        {
             if (PropertyChanged != null)
                 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    <Window x:Class="TheTestingProject_WPF_.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <Viewbox>
            <CheckBox IsChecked="{Binding Path=Test, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
        </Viewbox>
    </Grid>
