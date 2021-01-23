    <Window x:Class="WpfApplication5.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow"
        Height="350"
        Width="525">
    <Grid>
        <ProgressBar Height="10"
                 HorizontalAlignment="Left"
                 Margin="12,12,0,0"
                 Name="progressBar1"
                 VerticalAlignment="Top"
                 Width="100"
                 Visibility="Hidden" />
        <Button Content="Button"
            Height="23"
            HorizontalAlignment="Left"
            Margin="30,54,0,0"
            Name="button1"
            VerticalAlignment="Top"
            Width="75"
            Click="button1_Click" />
    </Grid>
    </Window>
    using System;
    using System.Threading;
    using System.Windows;
    namespace WpfApplication5 {
        public partial class MainWindow : Window {
            public MainWindow() {
                InitializeComponent();
            }
            void button1_Click(object sender, RoutedEventArgs e) {
                progressBar1.Visibility = Visibility.Visible;
                Action method = () => {
                    Action<int> method2 = (val) => {
                        progressBar1.Value = val;
                    };
                    for (int i = 0 ; i < 10 ; i++) {
                        Thread.Sleep(500);
                        Dispatcher.BeginInvoke(method2, i * 10);
                    }
                    Action method3 = () => {
                        progressBar1.Visibility = Visibility.Hidden;
                    };
                    Dispatcher.BeginInvoke(method3);
                };
                method.BeginInvoke(null, null);
            }
        }
    }
