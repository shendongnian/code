    namespace WPFTestbed
    {
       /// <summary>
       /// Interaction logic for MainWindow.xaml
       /// </summary>
       public partial class MainWindow : Window
       {
          public static readonly RoutedEvent FlashEvent =
             EventManager.RegisterRoutedEvent("Flash",
             RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(MainWindow));
    
          public event RoutedEventHandler Flash
          {
             add { AddHandler(FlashEvent, value); }
             remove { RemoveHandler(FlashEvent, value); }
          }
    
          ObservableCollection<String> m_NotificationList;
    
          public ObservableCollection<String> NotificationList
          {
             get
             {
                return m_NotificationList;
             }
          }
    
          public MainWindow()
          {
             InitializeComponent();
    
             this.DataContext = this;
    
             m_NotificationList = new ObservableCollection<string>() { "hey", "ho", "lets", "go" };
             m_NotificationList.CollectionChanged += CollectionChangeCallback;
          }
    
          void CollectionChangeCallback(object sender, EventArgs e)
          {
             if (m_NotificationList.Count > 0)
                window.RaiseEvent(new RoutedEventArgs(FlashEvent));
          }
          private void Button_Click(object sender, RoutedEventArgs e)
          {
             m_NotificationList.Add("Another");
          }
       }
    }
