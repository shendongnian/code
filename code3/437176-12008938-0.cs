protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
{
	if (resultCode == Result.Ok && requestCode == 1001)
    {
		Android.Net.Uri _currentImageUri = Android.Net.Uri.Parse(_imageUri);
		Bitmap bitmap = BitmapFactory.DecodeStream(ContentResolver.OpenInputStream(_currentImageUri));
            
		byte[] bitmapData = null;
            
		using (MemoryStream stream = new MemoryStream())
		{
			bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
			bitmapData = stream.ToArray();
		}
        bitmap.Dispose();
	}
}
