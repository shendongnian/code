	class mydict
	{
		public static Dictionary<string, Bitmap> MyLookup { get; private set; }
		public static void loadDict()
		{
                        MyLookup.Clear();
			Bitmap l1 = new Bitmap(@"C:\1\1.bmp", true);
			MyLookup.Add("1", l1);
		}
	}
