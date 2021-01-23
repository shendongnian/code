    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Canvas  Name="paintSurface" MouseDown="Canvas_MouseDown_1" MouseMove="Canvas_MouseMove_1" >
            <Canvas.Background>
                <SolidColorBrush Color="White" Opacity="0"/>
            </Canvas.Background>
        </Canvas>
    </Window>
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Shapes;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
    
            Point currentPoint = new Point();
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                if (e.ButtonState == MouseButtonState.Pressed)
                    currentPoint = e.GetPosition(this);
            }
    
            private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Line line = new Line();
    
                    line.Stroke = SystemColors.WindowFrameBrush;
                    line.X1 = currentPoint.X;
                    line.Y1 = currentPoint.Y;
                    line.X2 = e.GetPosition(this).X;
                    line.Y2 = e.GetPosition(this).Y;
    
                    currentPoint = e.GetPosition(this);
    
                    paintSurface.Children.Add(line);
                }
            }
    
        }
    }
