	public void SetHeader(HttpWebRequest Request, string Header, string Value) {
		// Retrieve the property through reflection.
		PropertyInfo PropertyInfo = Request.GetType().GetProperty(Header.Replace("-", string.Empty));
		// Check if the property is available.
		if (PropertyInfo != null) {
			// Set the value of the header.
			PropertyInfo.SetValue(Request, Value, null);
		} else {
			// Set the value of the header.
			Request.Headers[Header] = Value;
		}
	}
