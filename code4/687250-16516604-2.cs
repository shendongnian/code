    public class SecondaryWindow : Window
    {
       public MouseButtonEventHandler MouseLeftButtonDownSubscriber
       {
          set { MouseLeftButtonDown += value; }
       }
    }
