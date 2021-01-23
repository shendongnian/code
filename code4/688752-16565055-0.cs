    private void calenderItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
       var selectedDate = /*calender's selected item*/;
       var lastPage = NavigationService.BackStack.FirstOrDefault();
       string pageName = lastPage.ToString();
       NavigationService.Navigate(new Uri(pageName+"?date="+selectedDate, UriKind.Relative));
    }
