        using System.Windows;
        using System.Windows.Input;
        using System.Diagnostics;
        using System.Runtime.InteropServices;
        using System;
        using System.Windows.Threading;
        namespace Test
        {
            public partial class MainWindow : Window
            {
                [DllImport("user32.dll")]
                [return: MarshalAs(UnmanagedType.Bool)]
                internal static extern bool GetCursorPos(ref Win32Point pt);
                [StructLayout(LayoutKind.Sequential)]
                internal struct Win32Point
                {
                    public Int32 X;
                    public Int32 Y;
                };
                public static Point GetMousePosition()
                {
                    Win32Point w32Mouse = new Win32Point();
                    GetCursorPos(ref w32Mouse);
                    return new Point(w32Mouse.X, w32Mouse.Y);
                }
                private double screenWidth;
                private double screenHeight;
                public MainWindow()
                {
                    InitializeComponent();
                }
                private void Window_Loaded(object sender, RoutedEventArgs e)
                {
                    screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
                    screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
                    this.Width = screenWidth;
                    this.Height = screenHeight;
                    this.Top = 0;
                    this.Left = 0;
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Tick += new EventHandler(timer_Tick);
                    timer.Start();
                }
                void timer_Tick(object sender, EventArgs e)
                {
                    var mouseLocation = GetMousePosition();
                    elipse1.Margin = new Thickness(mouseLocation.X, mouseLocation.Y, screenWidth - mouseLocation.X - elipse1.Width, screenHeight - mouseLocation.Y- elipse1.Height);
                }
            }
        }
