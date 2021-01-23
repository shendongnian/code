	private function GetAuthorization(string username, string password, string domain) 
	{
		string credentials = string.Format(@"{0}\{1}:{2}", domain, username, password);
		byte[] bytes = Encoding.ASCII.GetBytes(credentials);
		string base64 = Convert.ToBase64String(bytes);
		return = string.Concat("NTLM ", base64);
	}
