        public static string HTTP_Post(string url, string data, DataType type = DataType.XML)
		{
			byte[] arr = System.Text.Encoding.UTF8.GetBytes(data);
			return new StreamReader(HTTP_Post_Response(url, arr, type)).ReadToEnd();
		}
		public static string HTTP_Post(string url, FileInfo file, DataType type = DataType.XML)
		{
			StreamReader fs = new StreamReader(file.OpenRead());
			byte[] arr = System.Text.Encoding.UTF8.GetBytes(fs.ReadToEnd());
			fs.Close();
			return new StreamReader(HTTP_Post_Response(url, arr, type)).ReadToEnd();
		}
		private static Stream HTTP_Post_Response(string url, byte[] data, DataType type)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
			request.Method = "POST";
			switch (type)
			{
				case DataType.Text:
					request.ContentType = "text/text"; break;
				case DataType.XML:
					request.ContentType = "text/xml"; break;
			}
			request.ContentLength = data.Length;
			Stream dataStream = request.GetRequestStream();
			dataStream.Write(data, 0, data.Length);
			dataStream.Close();
			return request.GetResponse().GetResponseStream();
		}
		public enum DataType
		{
			Text = 0,
			XML,
		}
