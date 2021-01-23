            private static void ShowError(string message, string details)
            {
                ErrorWindow error = new ErrorWindow(message, details);
                error.Closed += new EventHandler(error_Closed);
                error.Show();
            }
    
            static void error_Closed(object sender, EventArgs e)
            {
                Application.Current.RootVisual.SetValue(Control.IsEnabledProperty, true);
            }
