    public class ExternalHyperlinkBehavior : Behavior<Hyperlink>
	{
		protected override void OnAttached()
		{
			base.OnAttached();
			this.AssociatedObject.RequestNavigate += AssociatedObject_RequestNavigate;
		}
		protected override void OnDetaching()
		{
			this.AssociatedObject.RequestNavigate -= AssociatedObject_RequestNavigate;
			base.OnDetaching();
		}
		void AssociatedObject_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}
	}
