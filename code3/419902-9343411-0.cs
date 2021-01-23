		void Main()
		{
			int rows = 100;
			int columns = 100;
		
			var random = new Random(DateTime.Now.Ticks.GetHashCode());
			
			byte[] bytes = Enumerable
				.Range(0, columns * rows)
				
				// White
				.SelectMany(i => new[] { (byte)0xFF, (byte)0xFF, (byte)0xFF, } )
				
				// Random
				/*.SelectMany(i => 
					{
						byte[] buffer = new byte[3];
						random.NextBytes(buffer);
						return buffer; 
					})*/
					
				.ToArray();
			
			using (var bm = Plot24(ref bytes, columns))
			{
				bm.Save(@"c:\test.bmp", ImageFormat.Bmp);
			}
		}
		
		public static Bitmap Plot24(ref byte[] bufferArray, int columns)
		{
			int position = 0;      
			int lengthOfBufferArray = bufferArray.Length;
			int rows = (int)Math.Ceiling((double)lengthOfBufferArray / (3*columns) );
			// ... the rest of your code is just fine
