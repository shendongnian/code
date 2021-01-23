    //Check for the first page and remove the remaining back stack in your ThirdPage.xaml
      while(!NavigationService.BackStack.First().Source.OriginalString.Contains("FirstPage"))
      {
          NavigationService.RemoveBackEntry();
      }
      NavigationService.GoBack(); 
