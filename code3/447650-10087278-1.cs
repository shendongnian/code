		static void Main(string[] args)
		{
			Random r = new Random();
			int i = 0;
			WebCrawl(() => (i = r.Next()) % 100 == 0 ? null : ("Some URL: " + i.ToString()),
				(url) => Console.WriteLine(url),
				500);
			Console.Read();
		}
