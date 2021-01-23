	private void dcdEvent_Scanned(object sender, DecodeEventArgs e)
	{
		CodeId cID = CodeId.NoData;
		string dcdData = string.Empty;
		// Obtain the string and code id.
		try
		{
			dcdData = hDcd.ReadString(e.RequestID, ref cID);
		}
		catch(Exception)
		{
			MessageBox.Show("Error reading string!");
			return;
		}
        string result = "Barcode Text: " + dcdData;
        result +=" AND Barcode Code Id : " + cID.ToString();
        MessageBox.Show(result);
    }
