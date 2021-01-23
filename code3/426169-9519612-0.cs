    public partial class Window1 : Window
    {
       readonly DispatcherTimer m_timer = new DispatcherTimer();
       public Window1()
       {
           InitializeComponent();
           m_timer.Interval = TimeSpan.FromSeconds(4);
           m_timer.Tick += TimerOnTick;
       }
       private void button1_Click(object sender, RoutedEventArgs e)
       {
           label1.Content = "Button 1 Clicked";
           m_timer.Start();
       }
       private void TimerOnTick(object sender, EventArgs eventArgs)
       {
           m_timer.Stop();
           label1.Content1 = ...
       }
