    public partial class MainWindow : Window
    {
      public void YourDispatcherTimer_Tick(object sender, EventArgs args)
      {
        YourProgressBar.Value = calculation.PercentComplete;
      }
    }
