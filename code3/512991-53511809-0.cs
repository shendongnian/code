    public partial class MyForm : Form
	{
		private readonly AddressFinder _addressFinder;
		private readonly AddressSuggestionsUpdatedEventHandler _addressSuggestionsUpdated;
		private delegate void AddressSuggestionsUpdatedEventHandler(object sender, AddressSuggestionsUpdatedEventArgs e);
		public MyForm()
		{
			InitializeComponent();
			_addressFinder = new AddressFinder(new AddressFinderConfigurationProvider());
			_addressSuggestionsUpdated += AddressSuggestions_Updated;
			MyComboBox.DropDownStyle = ComboBoxStyle.DropDown;
			MyComboBox.DisplayMember = "Value";
			MyComboBox.ValueMember = "Key";
		}
		private void MyComboBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsControl(e.KeyChar))
			{
				return;
			}
			var searchString = ThreadingHelpers.GetText(MyComboBox);
			if (searchString.Length > 1)
			{
				Task.Run(() => GetAddressSuggestions(searchString));
			}
		}
		private async Task GetAddressSuggestions(string searchString)
		{
			var addressSuggestions = await _addressFinder.CompleteAsync(searchString).ConfigureAwait(false);
			if (_addressSuggestionsUpdated.IsNotNull())
			{
				_addressSuggestionsUpdated.Invoke(this, new AddressSuggestionsUpdatedEventArgs(addressSuggestions));
			}
		}
		private void AddressSuggestions_Updated(object sender, AddressSuggestionsUpdatedEventArgs eventArgs)
		{
			try
			{
				ThreadingHelpers.BeginUpdate(MyComboBox);
				var text = ThreadingHelpers.GetText(MyComboBox);
				ThreadingHelpers.ClearItems(MyComboBox);
				foreach (var addressSuggestions in eventArgs.AddressSuggestions)
				{
					ThreadingHelpers.AddItem(MyComboBox, addressSuggestions);
				}
				ThreadingHelpers.SetDroppedDown(MyComboBox, true);
				ThreadingHelpers.ClearSelection(MyComboBox);
				ThreadingHelpers.SetText(MyComboBox, text);
				ThreadingHelpers.SetSelectionStart(MyComboBox, text.Length);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				ThreadingHelpers.EndUpdate(MyComboBox);
			}
		}
		private class AddressSuggestionsUpdatedEventArgs : EventArgs
		{
			public IList<KeyValuePair<string, string>> AddressSuggestions { get; private set; }
			public AddressSuggestionsUpdatedEventArgs(IList<KeyValuePair<string, string>> addressSuggestions)
			{
				AddressSuggestions = addressSuggestions;
			}
		}
	}
