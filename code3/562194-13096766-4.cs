    using System;
    using System.Collections.Generic;
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
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public static bool AddItem = false; //This must be public and static so that it can be called from your second Window
            public Window1()
            {
                InitializeComponent();
            }
            public void AddToScrollViewer()
            {
                Button _Object = new Button(); //Create a new object, change button to the UIElement you would like to be
                stackPanel.Children.Add(_Object); //Add the UIElement to the StackPanel
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer(); //Initialize a new timer object
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick); //Link the Tick event with dispatcherTimer_Tick
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1); //Set the Timer Interval
                dispatcherTimer.Start(); //Start the Timer
            }
    
            private void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                if (AddItem)
                {
                    AddItem = false;
                    AddToScrollViewer();
                }
            }
        }
    }
