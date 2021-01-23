    public partial class ChargementAvion :Window
    {
       public event Action<string> OnDone;
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(OnDone != null)
            { 
               OnDone("any string you want to pass");
            }
        }
    }
