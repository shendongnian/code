    private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
    		{
    			// Set the root visual to allow the application to render
    			if (RootVisual != RootFrame)
    				RootVisual = RootFrame;
    
    			// Remove this handler since it is no longer needed
    			RootFrame.Navigated -= CompleteInitializePhoneApplication;
    			// Add this to inject the media element Control template
    			RootFrame.Template = Current.Resources["WhiteTemplate"] as ControlTemplate;
    		}
