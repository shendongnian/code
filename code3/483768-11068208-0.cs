    public class MyViewModel : INotifyPropertyChanged
    {
        public static readonly RoutedEvent RequestCloseEvent = EventManager.RegisterRoutedEvent("RequestClose",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyViewModel));
    
        private IInputElement dispatcher;
    
        public MyViewModel(IInputElement dispatcher)
        {
            this.dispatcher = dispatcher;
        }
    
        public void CloseApplication()
        {
            dispatcher.RaiseEvent(new RoutedEventArgs(RequestCloseEvent));
        }
    }
