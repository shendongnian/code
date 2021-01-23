    	private void ToastWrapWithImgAndTitleClick(object sender, RoutedEventArgs e)
    	{
    		var toast = GetToastWithImgAndTitle();
    		toast.TextWrapping = TextWrapping.Wrap;
    
    		toast.Show();
    	}
    
    	private static ToastPrompt GetToastWithImgAndTitle()
    	{
    		return new ToastPrompt
    		{
    			Title = "With Image",
    			TextOrientation = System.Windows.Controls.Orientation.Vertical,
    			Message = LongText,
    			ImageSource = new BitmapImage(new Uri("../../ApplicationIcon.png", UriKind.RelativeOrAbsolute))
    		};
    	}
