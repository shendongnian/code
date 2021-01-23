	using System.Windows;
	using System.Windows.Documents;
	using System.Windows.Navigation;
	using Microsoft.Xaml.Behaviors;
	
	namespace YourNameSpace
	{
		public class HyperlinkOpenBehaviour : Behavior<Hyperlink>
		{
			public static readonly DependencyProperty ConfirmNavigationProperty = DependencyProperty.Register(
    			nameof(ConfirmNavigation), typeof(bool), typeof(HyperlinkOpenBehaviour), new PropertyMetadata(default(bool)));
    
			public bool ConfirmNavigation
    		{
    			get { return (bool) GetValue(ConfirmNavigationProperty); }
    			set { SetValue(ConfirmNavigationProperty, value); }
    		}
    
    		/// <inheritdoc />
    		protected override void OnAttached()
    		{
    			this.AssociatedObject.RequestNavigate += NavigationRequested;
    			this.AssociatedObject.Unloaded += AssociatedObjectOnUnloaded;
    			base.OnAttached();
    		}
    
    		private void AssociatedObjectOnUnloaded(object sender, RoutedEventArgs e)
    		{
    			this.AssociatedObject.Unloaded -= AssociatedObjectOnUnloaded;
    			this.AssociatedObject.RequestNavigate -= NavigationRequested;
    		}
    
    		private void NavigationRequested(object sender, RequestNavigateEventArgs e)
    		{
    			if (!ConfirmNavigation || MessageBox.Show("Are you sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
    			{
    				OpenUrl();
    			}
    
    			e.Handled = true;
    		}
    
    		private void OpenUrl()
    		{
    //			Process.Start(new ProcessStartInfo(AssociatedObject.NavigateUri.AbsoluteUri));
    			MessageBox.Show($"Opening {AssociatedObject.NavigateUri}");
    		}
    
    		/// <inheritdoc />
    		protected override void OnDetaching()
    		{
    			this.AssociatedObject.RequestNavigate -= NavigationRequested;
    			base.OnDetaching();
    		}
    	}
    }
