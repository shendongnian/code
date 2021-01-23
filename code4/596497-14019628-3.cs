    public class Automator
    {
       public static void Post(NdWindow ndWindow)
       {
           ndWindow.setprogress(10);
       }
    }
    public partial class NdWindow : Window
    {
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Automator.Post(this);
        }
    }
