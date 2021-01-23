    void Main()
    {
	byte[] login = BitConverter.GetBytes("loginstring");
	byte[] img = BitConverter.GetBytes("fakeimagedataherereplacewithrealbytes");
	byte[] tosend = login.Concat(img).ToArray();
	using(WebRequest wr = WebRequest.Create("someurl"))
	{
		using (Stream rs = wr.GetRequestStream())
		{
			rs.Write(LoginBytes, 0, LoginBytes.Length);
			//...whatever
		}
			
	}
}
