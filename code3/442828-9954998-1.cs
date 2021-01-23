     public static Dictionary<string, Bitmap> loadDict()
    		{
                        var dict = new Dictionary<string, Bitmap>();
    			Bitmap l1 = new Bitmap(@"C:\1\1.bmp", true);
    			dict .Add("1", l1);
                        return dict;
    		}
