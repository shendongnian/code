	if (address != null)
	{
		var deviceLocation = new StringBuilder();
		for (var i = 0; i < address.MaxAddressLineIndex; i++)
		{
			deviceLocation.Append(address.GetAddressLine(i))
				.AppendLine(",");
		}
		// Here you were updating the UI thread from the background:
		RunOnUiThread(() => _addressText.Text = deviceLocation.ToString());
	}
