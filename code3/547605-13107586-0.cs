     protected virtual void GoBack(object sender, RoutedEventArgs e)
            {
                while (this.Frame.CanGoBack) this.Frame.GoBack();
                // Use the navigation frame to return to the previous page
                //if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
            } 
