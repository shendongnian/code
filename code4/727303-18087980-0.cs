     if((IsolatedStorageSettings.ApplicationSettings.Contains("LocationConsent")) && ((bool)IsolatedStorageSettings.ApplicationSettings["LocationConsent"] == true))
            {   return; }
            else
            {      MessageBoxResult result =
                    MessageBox.Show("This app accesses your phone's location. Is that ok?",
                    "Location",
                    MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = true;  }
                else
                {IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = false;  }
                IsolatedStorageSettings.ApplicationSettings.Save();         
   }
