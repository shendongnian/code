	/// <summary>
	/// Class to provide assistance for separation of concern
	/// over contents of combo box where the
	/// displayed value does not match the ToString 
	/// support.
	/// </summary>
	/// <typeparam name="T">The type of the value the combo box supports</typeparam>
	[DebuggerDisplay("ComboBoxLoader {Display} {Value.ToString()}")]
	public class ComboBoxLoader<T>
	{
		/// <summary>
		/// The value to display in the combo box
		/// </summary>
		public string Display { get; set; }
		/// <summary>
		/// The actual object associated with the combo box item
		/// </summary>
		public T Value { get; set; }
	}
