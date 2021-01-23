	public partial class MyRandomClass: IAutoNotifyPropertyChanged
	{
		/// <summary>
		/// Create a new empty instance and <see cref="PropertySpecifiedExtensions.Autospecify"/> its properties when changed
		/// </summary>
		/// <returns></returns>
		public static MyRandomClass Create()
		{
			return PropertySpecifiedExtensions2.Create<MyRandomClass>();
		}
		public void WhenPropertyChanges(string propertyName)
		{
			switch (propertyName)
			{
				case "field1": this.field1Specified = true; return;
				// etc
			}
			// etc
			if(propertyName.StartsWith(...)) { /* do other stuff */ }
		}
	}
