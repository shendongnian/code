      class MyPage : Page
      {
        private MyUserControl myUserControl; // It is only for illustrations, Otherwise it goes to .designer.cs
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           Title.Text = e.Parameter.ToString();
           myUserControl.Parameter = e.Parameter; // This is how to set the parameter in usercontrol.
         }
       }
    
