    yes it is. You can create a `VoltageChanelView` collection , and then create a datatemplate for it. i think this way it`s easier for you to display it.
    
    First I don't really understand what you are trying to accomplish with all those grid rows and so on. but maybe using a listview instead a grid divided in 9 rows will make it simpler.
    
    
    Implement this classes...
    
    
    namespace TestWpf
    {
        class VoltageChangeModel : INotifyPropertyChanged
        {
            private int _Voltage = 0;
            private string _ChanelName = "";
            private Brush color = Brushes.Blue;
    
            public Brush Color
            {
                set
                {
    
                    if (value != color)
                    {
                        onPropertyChanged("Color");
                        color = value;
                    }
                }
                get
                {
                    return color;
                }
    
            }
            public int Voltage
            {
                set
                {
    
                    if (value != _Voltage)
                    {
                        onPropertyChanged("Voltage");
                        _Voltage = value;
                    }
                }
                get
                {
                    return _Voltage;
                }
            }
            public String ChanelName
            {
                set
                {
                    if (value != _ChanelName)
                    {
                        onPropertyChanged("ChanelName");
                        _ChanelName = value;
                    }
                }
    
                get
                {
                    return _ChanelName;
                }
            }
            public VoltageChangeModel(int Voltage, string ChanelName, Brush Color)
            {
                this.ChanelName = ChanelName;
                this.Voltage = Voltage;
                this.Color = Color;
            }
            public override string ToString()
            {
                return _ChanelName;
            }
    
    
    
    
            public void onPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
    
    next this clas.... 
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    
    namespace TestWpf
    {
        class ChanellList : ObservableCollection<VoltageChangeModel>
        {
            
        }
    }
     in the mainWindow this code  after <window ,,,,,,,,,,,>
    
    
        <Grid>
            <ListBox x:Name="myViewChannelList" HorizontalAlignment="Left" Height="161" ItemsSource="{Binding}" Margin="82,38,0,0" VerticalAlignment="Top" Width="187">
                <ListBox.ItemTemplate>
                    <DataTemplate >
                        <StackPanel Background="{Binding Path=Color}">
                        <Label Content="{Binding Path=Voltage}" ></Label>
                        <Label Content="{Binding Path=ChanelName}"></Label>
                           
                        </StackPanel>
                    </DataTemplate>
                    
                </ListBox.ItemTemplate>
                
            </ListBox>
        
        </Grid>
    </Window>
    
    
    
    and then in code behind set the data context.
    
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace TestWpf
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                ChanellList myChanels = new ChanellList();
                myChanels.Add(new VoltageChangeModel(30,"Channel 1 " , Brushes.Blue ));
                myChanels.Add(new VoltageChangeModel(30, "Channel 1 ", Brushes.Red));
                myViewChannelList.DataContext = myChanels;
            }
        }
    }
