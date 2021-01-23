    namespace WpfApplication1{
        /// <summary>
        /// Interaction logic for Bla.xaml
        /// </summary>
        public partial class Bla : UserControl
        {
            public event RoutedEventHandler changeHaus
            {
                add { AddHandler(myEvents.changeHausEvent, value); }
                remove { RemoveHandler(myEvents.changeHausEvent, value); }
            }
            public event RoutedEventHandler changeSoccer
            {
                add { AddHandler(myEvents.changeSoccerEvent, value); }
                remove { RemoveHandler(myEvents.changeSoccerEvent, value); }
            }
            public Bla()
            {
                InitializeComponent();
            }
            private void ButtonClick(object sender, RoutedEventArgs e) { 
                Button btn = sender as Button; 
                if (btn.Content.ToString() == "House")
                {
                    SetHaus();
                    RoutedEventArgs ea = new RoutedEventArgs(myEvents.changeHausEvent);
                    RaiseEvent(ea);
                }
                else if (btn.Content.ToString() == "Soccer")
                {
                    SetSoccer();
                    RoutedEventArgs ea = new RoutedEventArgs(myEvents.changeSoccerEvent);
                    RaiseEvent(ea);
                }
            } 
 
            public void SetHaus()
            {
                display.Fill = new SolidColorBrush(Colors.Blue);
            }
            public void SetSoccer()
            {
                display.Fill = new SolidColorBrush(Colors.Red);
            }
        }
        public static class myEvents
        {
            public static  RoutedEvent changeHausEvent = EventManager.RegisterRoutedEvent("changeHaus",RoutingStrategy.Tunnel,typeof(RoutedEventHandler), typeof(Bla));
            public static RoutedEvent changeSoccerEvent = EventManager.RegisterRoutedEvent("changeSoccer", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(Bla));
        
        }
    }
