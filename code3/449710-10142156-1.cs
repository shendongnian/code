	public partial class AbstractView : UserControl
	{
		public AbstractView()
		{
			InitializeComponent();
			DataContextChanged += Changed;
		}
		void Changed(object sender, DependencyPropertyChangedEventArgs e)
		{
			AbstractViewModel ob = e.NewValue as AbstractViewModel;
			var props = ob.GetType().GetProperties();
			foreach (var prop in props)
			{
				if (prop.PropertyType == "".GetType())
					addStringProperty(prop);
				else if (prop.PropertyType == 1.GetType())
					addIntProperty(prop);
				else if (prop.PropertyType == true.GetType())
					addBoolProperty(prop);
				else
				{
				}
			}
		}
		void addBoolProperty(PropertyInfo prop) {
			CheckBox bx = new CheckBox();
			bx.SetBinding(CheckBox.IsCheckedProperty, getBinding(prop));
			if (!prop.CanWrite)
				bx.IsEnabled = false;
			addUniformGrid(bx, prop);
		}
		void addStringProperty(PropertyInfo prop)
		{
			TextBox bx = new TextBox();
			bx.SetBinding(TextBox.TextProperty, getBinding(prop));
			if (!prop.CanWrite)
				bx.IsEnabled = false;
			addUniformGrid(bx, prop);
		}
		void addIntProperty(PropertyInfo prop)
		{
			TextBlock bl = new TextBlock();
			bl.SetBinding(TextBlock.TextProperty, getBinding(prop));
			addUniformGrid(bl, prop);
		}
		void addUniformGrid(UIElement ctrl, PropertyInfo prop)
		{
			Label lb = new Label();
			lb.Content = prop.Name;
			UniformGrid u = new UniformGrid();
			u.Rows = 1;
			u.Columns = 2;
			u.Children.Add(lb);
			u.Children.Add(ctrl);
			container.Children.Add(u);
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
