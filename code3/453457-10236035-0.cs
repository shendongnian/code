    private Dictionary<string, string> dictionary = new Dictionary<string, string>();
    private void txt_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
		string key = textBox.Name;
		string value = textBox.Text;
		if (!dictionary.ContainsKey(key))
		{
			dictionary.Add(key, value);
		}
		else
		{
			dictionary[key] = value;
		}
    }
