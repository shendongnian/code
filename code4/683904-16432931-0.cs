		/// <summary>
		/// Return the contents of the enumeration as formatted for a combo box
		/// relying on the Description attribute containing the display value
		/// within the enum definition
		/// </summary>
		/// <typeparam name="T">The type of the enum being retrieved</typeparam>
		/// <returns>The collection of enum values and description fields</returns>
		public static ICollection<ComboBoxLoader<T>> GetEnumComboBox<T>()
		{
			ICollection<ComboBoxLoader<T>> result = new List<ComboBoxLoader<T>>();
			foreach (T e in Enum.GetValues(typeof(T)))
			{
				ComboBoxLoader<T> value = new ComboBoxLoader<T>();
				try
				{
					value.Display = GetDescription(e);
				}
				catch (NullReferenceException)
				{
					// This exception received when no Description attribute
					// associated with Enum members
					value.Display = e.ToString();
				}
				value.Value = e;
				result.Add(value);
			}
			return result;
		}
