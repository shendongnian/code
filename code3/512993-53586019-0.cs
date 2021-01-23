	public partial class TestForm : Form
	{
		// Custom class for managing calls to an external address finder service
		private readonly AddressFinder _addressFinder;
		// Events for handling async calls to address finder service
		private readonly AddressSuggestionsUpdatedEventHandler _addressSuggestionsUpdated;
		private delegate void AddressSuggestionsUpdatedEventHandler(object sender, AddressSuggestionsUpdatedEventArgs e);
		public TestForm()
		{
			InitializeComponent();
			_addressFinder = new AddressFinder(new AddressFinderConfigurationProvider());
			_addressSuggestionsUpdated += AddressSuggestions_Updated;
		}
		private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Tab)
			{
				comboBox1_SelectionChangeCommitted(sender, e);
				comboBox1.DroppedDown = false;
			}
		}
		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				if (comboBox1.Items.Count > 0)
				{
					if (comboBox1.SelectedIndex > 0)
					{
						comboBox1.SelectedIndex--;
					}
				}
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Down)
			{
				if (comboBox1.Items.Count > 0)
				{
					if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
					{
						comboBox1.SelectedIndex++;
					}
				}
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Enter)
			{
				comboBox1_SelectionChangeCommitted(sender, e);
				comboBox1.DroppedDown = false;
				textBox1.SelectionStart = textBox1.TextLength;
				e.Handled = true;
			}
		}
		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')	// Enter key
			{
				e.Handled = true;
				return;
			}
			if (char.IsControl(e.KeyChar) && e.KeyChar != '\b')	// Backspace key
			{
				return;
			}
			if (textBox1.Text.Length > 1)
			{
				Task.Run(() => GetAddressSuggestions(textBox1.Text));
			}
		}
		private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (comboBox1.Items.Count > 0 &&
				comboBox1.SelectedItem.IsNotNull() &&
				comboBox1.SelectedItem is KeyValuePair<string, string>)
			{
				var selectedItem = (KeyValuePair<string, string>)comboBox1.SelectedItem;
				textBox1.Text = selectedItem.Value;
				// Do Work with selectedItem
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
				ThreadingHelper.BeginUpdate(comboBox1);
				ThreadingHelper.ClearItems(comboBox1);
				if (eventArgs.AddressSuggestions.Count > 0)
				{
					foreach (var addressSuggestion in eventArgs.AddressSuggestions)
					{
						var item = new KeyValuePair<string, string>(addressSuggestion.Key, addressSuggestion.Value.ToUpper());
						ThreadingHelper.AddItem(comboBox1, item);
					}
					ThreadingHelper.SetDroppedDown(comboBox1, true);
					ThreadingHelper.SetVisible(comboBox1, true);
				}
				else
				{
					ThreadingHelper.SetDroppedDown(comboBox1, false);
				}
			}
			finally
			{
				ThreadingHelper.EndUpdate(comboBox1);
			}
		}
		private class AddressSuggestionsUpdatedEventArgs : EventArgs
		{
			public IList<KeyValuePair<string, string>> AddressSuggestions { get; }
			public AddressSuggestionsUpdatedEventArgs(IList<KeyValuePair<string, string>> addressSuggestions)
			{
				AddressSuggestions = addressSuggestions;
			}
		}
	}
