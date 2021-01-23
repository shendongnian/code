    public static class Extension
    	{
    		public static void Dump<T>(this T o)
    		{
    			string localUrl = Path.GetTempFileName() + ".html";
    			using (var writer = LINQPad.Util.CreateXhtmlWriter(true))
    			{
    				writer.Write(o);
    				File.WriteAllText(localUrl, writer.ToString());
    			}
    			Process.Start(localUrl);
    		}
    	}
