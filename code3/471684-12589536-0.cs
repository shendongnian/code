	public static class LinqPadExtensions
	{
		/// <summary>
		/// Writes object properties to HTML 
		/// and displays them in default browser.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="o"></param>
		/// <param name="heading"></param>
		public static void Dump<T>(
			this T o,
			string heading = null
		)
		{
			string localUrl =
				Path.GetTempFileName() + ".html";
			using (
				var writer =
					LINQPad.Util.CreateXhtmlWriter(true)
			)
			{
				if (!String.IsNullOrWhiteSpace(heading))
					writer.Write(heading);
				writer.Write(o);
				File.WriteAllText(localUrl, writer.ToString());
			}
			Process.Start(localUrl);
		}
	}
