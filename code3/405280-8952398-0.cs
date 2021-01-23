   	public class InvokeCommandOnTextChanged : Behavior<TextBox>
	{
		public static DependencyProperty CommandProperty =
			DependencyProperty.Register("Command", typeof(ICommand), typeof(InvokeCommandOnTextChanged));
		public static DependencyProperty CommandParameterProperty =
			DependencyProperty.Register("CommandParameter", typeof(object), typeof(InvokeCommandOnTextChanged));
		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}
		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}
		protected override void OnAttached()
		{
			base.OnAttached();
			this.AssociatedObject.TextChanged += OnTextChanged;
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.AssociatedObject.TextChanged -= OnTextChanged;
		}
		private void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var command = this.Command;
			var param = this.CommandParameter;
			if (command != null && command.CanExecute(param))
			{
				command.Execute(param);
			}
		}
	}
