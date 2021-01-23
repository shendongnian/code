    using (var inStream = ContentResolver.OpenInputStream(Android.Net.Uri.Parse("YourBitmapUri")))
    {
    	using (var decoder = BitmapRegionDecoder.NewInstance(inStream, false))
    	{
    		var bitmap = decoder.DecodeRegion(YourRect, new BitmapFactory.Options());
    		// use your bitmap i.e. for an ImageView
    		bitmap.Dispose();
    	}
    }
