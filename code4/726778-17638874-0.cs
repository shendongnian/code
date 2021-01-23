    		private void ResizeBitmapAndSendToWebServer(string album_id) {
    
    			BitmapFactory.Options options = new BitmapFactory.Options ();
    			options.InJustDecodeBounds = true; // <-- This makes sure bitmap is not loaded into memory.
    			// Then get the properties of the bitmap
    			BitmapFactory.DecodeFile (fileUri.Path, options);
    			Android.Util.Log.Debug ("[BITMAP]" , string.Format("Original width : {0}, and height : {1}", options.OutWidth, options.OutHeight) );
    			// CalculateInSampleSize calculates the right aspect ratio for the picture and then calculate
    			// the factor where it will be downsampled with.
    			options.InSampleSize = CalculateInSampleSize (options, 1600, 1200);
    			Android.Util.Log.Debug ("[BITMAP]" , string.Format("Downsampling factor : {0}", CalculateInSampleSize (options, 1600, 1200)) );
    			// Now that we know the downsampling factor, the right sized bitmap is loaded into memory.
    			// So we set the InJustDecodeBounds to false because we now know the exact dimensions.
    			options.InJustDecodeBounds = false;
    			// Now we are loading it with the correct options. And saving precious memory.
    			Bitmap bm = BitmapFactory.DecodeFile (fileUri.Path, options);
    			Android.Util.Log.Debug ("[BITMAP]" , string.Format("Downsampled width : {0}, and height : {1}", bm.Width, bm.Height) );
    			// Convert it to Base64 by first converting the bitmap to
    			// a byte array. Then convert the byte array to a Base64 String.
    			MemoryStream stream = new MemoryStream ();
    			bm.Compress (Bitmap.CompressFormat.Jpeg, 80, stream);
    			byte[] bitmapData = stream.ToArray ();
    			bm.Dispose ();
    			app.api.SendPhoto (Base64.EncodeToString (bitmapData, Base64Flags.Default), album_id);
    
    		}
