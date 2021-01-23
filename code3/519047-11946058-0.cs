        Response.ContentType = "text/csv";
		Response.Cache.SetNoStore();
		Response.Buffer = true;
		Response.BufferOutput = true;
		Response.Charset = "UTF-8";
		Response.ContentEncoding = System.Text.Encoding.Unicode;
		Response.Write("Company, City, Country");
		//IF you want each item in each cell of a row
		byte[] buffer = System.Text.Encoding.Unicode.GetBytes(Separater(Name) + Separater(City) +Separater(Country) +  "\r\n")
		Response.OutputStream.Write(buffer, 0, buffer.Length);
		Response.OutputStream.Flush();
												
												
		private string Separater(string text)
		{
			if (text == null)
			{
				return "\"\",";
			}
			return "\"" + text.Replace("\"", "'") + "\"" + ",";
		}
