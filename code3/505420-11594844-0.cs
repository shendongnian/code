    public void Each_Tick(object o, EventArgs sender) 
    { 
       timerBlock.Text = "Time: " + i--.ToString() + "s";
       if(i = 0)
       {
             NavigationService.Navigate(new Uri("/gameOver.xaml", UriKind.Relative));
       }
    }
