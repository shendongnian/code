		public Binding ReflectionBinder(string propertyName)
		{
			var binding = new Binding();
			var src = (from i in DataModel.Entities.machine
			           where i.name == Properties.Settings.Default.CurrentMachine
			           select i);
			binding.Source = src.GetType().GetProperty(propertyName).GetValue(src, null);
			return binding;
		}
