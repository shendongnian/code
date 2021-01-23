	public class EnterKeyPropertyChangeBehaviour : Behavior<DependencyObject>
	{
		public EnterKeyPropertyChangeBehaviour()
		{
		}
		protected override void OnAttached()
		{
			base.OnAttached();
			// Insert code that you would want run when the Behavior is attached to an object.
			var fe = AssociatedObject as FrameworkElement;
			if (fe != null) fe.KeyDown += fe_KeyDown;
		}
		void fe_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
                using (dynamic shell = AutomationFactory.CreateObject("WScript.Shell"))
                {
                    shell.SendKeys("{TAB}");
                }	
			
			}
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			// Insert code that you would want run when the Behavior is removed from an object.
			var fe = AssociatedObject as FrameworkElement;
			if (fe != null) fe.KeyDown -= fe_KeyDown;
		}
	}
