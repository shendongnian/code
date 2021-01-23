    <Window x:Class="WpfApplication3.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Button Click="Button_Click" Content="Button" HorizontalAlignment="Left" Margin="441,289,0,0" VerticalAlignment="Top" Width="75"/>
            <ListBox HorizontalAlignment="Left" ItemsSource="{Binding MyList,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Name="lstbox" Height="296" Margin="21,23,0,0" VerticalAlignment="Top" Width="209"/>
    
        </Grid>
    </Window>
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private ObservableCollection<string> _myList = new ObservableCollection<string>(new List<string>(){"1","2","3"});
            int i = 3;  
           
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;  
            }
           
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                MyList.Add(i++.ToString());  
            }
            public ObservableCollection<string> MyList
            {
                get { return _myList; }
                set { _myList = value; }
            }
        }
    }
