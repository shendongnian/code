        //Temporarily hold the value got from the navigation 
        string textBoxValue = "";
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Retrieve the value passed during page navigation
             NavigationContext.QueryString.TryGetValue("text", out textBoxValue)               
        }
         private void button1_Click(object sender, RoutedEventArgs e) {
      
           MessageBox.Show(textBoxValue);
         }
