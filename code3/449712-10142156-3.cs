	public partial class AbstractView : UserControl
	{
		public AbstractView()
		{
			InitializeComponent();
			DataContextChanged += Changed;
		}
		void Changed(object sender, DependencyPropertyChangedEventArgs e)
		{
			object ob = e.NewValue;
			var props = ob.GetType().GetProperties();
			List<UIElement> uies = new List<UIElement>();
			foreach (var prop in props)
			{
				if (prop.PropertyType == typeof(String))
					uies.Add(makeStringProperty(prop));
				else if (prop.PropertyType == typeof(int))
					uies.Add(makeIntProperty(prop));
				else if (prop.PropertyType == typeof(bool))
					uies.Add(makeBoolProperty(prop));
				else if (prop.PropertyType == typeof(ICommand))
					uies.Add(makeCommandProperty(prop));
				else
				{
				}
			}
			StackPanel st = new StackPanel();
			st.Orientation = Orientation.Horizontal;
			st.HorizontalAlignment = HorizontalAlignment.Center;
			st.Margin = new Thickness(0, 20, 0, 0);
			foreach (var uie in uies) {
				if (uie is Button)
					st.Children.Add(uie);
				else
					container.Children.Add(uie);
			}
			if (st.Children.Count > 0)
				container.Children.Add(st);
		}
		UIElement makeCommandProperty(PropertyInfo prop)
		{
			var btn = new Button();
			btn.Content = prop.Name;
			var bn = new Binding(prop.Name);
			btn.SetBinding(Button.CommandProperty, bn);
			return btn;
		}
		UIElement makeBoolProperty(PropertyInfo prop)
		{
			CheckBox bx = new CheckBox();
			bx.SetBinding(CheckBox.IsCheckedProperty, getBinding(prop));
			if (!prop.CanWrite)
				bx.IsEnabled = false;
			return makeUniformGrid(bx, prop);
		}
		UIElement makeStringProperty(PropertyInfo prop)
		{
			TextBox bx = new TextBox();
			bx.SetBinding(TextBox.TextProperty, getBinding(prop));
			if (!prop.CanWrite)
				bx.IsEnabled = false;
			return makeUniformGrid(bx, prop);
		}
		UIElement makeIntProperty(PropertyInfo prop)
		{
			TextBlock bl = new TextBlock();
			bl.SetBinding(TextBlock.TextProperty, getBinding(prop));
			return makeUniformGrid(bl, prop);
		}
		UIElement makeUniformGrid(UIElement ctrl, PropertyInfo prop)
		{
			Label lb = new Label();
			lb.Content = prop.Name;
			UniformGrid u = new UniformGrid();
			u.Rows = 1;
			u.Columns = 2;
			u.Children.Add(lb);
			u.Children.Add(ctrl);
			return u;
		}
		Binding getBinding(PropertyInfo prop)
		{
			var bn = new Binding(prop.Name);
			if (prop.CanRead && prop.CanWrite)
				bn.Mode = BindingMode.TwoWay;
			else if (prop.CanRead)
				bn.Mode = BindingMode.OneWay;
			else if (prop.CanWrite)
				bn.Mode = BindingMode.OneWayToSource;
			return bn;
		}
	}
