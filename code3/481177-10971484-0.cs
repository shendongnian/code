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
            bla.Children.Clear();
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
            bla.Children.Clear();
            Haus uc1 = new Haus();
            bla.Children.Add(uc1); 
            
        }
        public void SetSoccer()
        {
             
            bla.Children.Clear();
            Fussball uc2 = new Fussball(); 
            bla.Children.Add(uc2);       
        }
    }
    public static class myEvents
    {
        public static  RoutedEvent changeHausEvent = EventManager.RegisterRoutedEvent("changeHaus",RoutingStrategy.Tunnel,typeof(RoutedEventHandler), typeof(Bla));
        public static RoutedEvent changeSoccerEvent = EventManager.RegisterRoutedEvent("changeSoccer", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(Bla));
        
    }
