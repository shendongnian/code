    private void hubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //vibrate
            if (Settings.EnableVibration.Value)
            {
                VibrateController.Default.Start(TimeSpan.FromMilliseconds(40));
            }
            //TileItem tap = sender as TileItem;
            HubTile tap = sender as HubTile;
            string _tap = tap.Title.ToString();  //NullReferenceException occurs here
            switch(_tap)
            {
                //case "shareStatus_Tap":
                case "status":
                    this.NavigationService.Navigate(new Uri("/Views/ShareStatusPage.xaml", UriKind.Relative));
                    break;
                //case "shareLink_Tap":
                case "link":
                    this.NavigationService.Navigate(new Uri("/Views/ShareLinkPage.xaml", UriKind.Relative));
                    break;
            }
        }
