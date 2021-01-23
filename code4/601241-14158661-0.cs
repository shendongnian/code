    ImageView iv = FindViewById<ImageView>(Resource.Id.imagePusher);
    Android.Graphics.BitmapFactory.Options options = new Android.Graphics.BitmapFactory.Options();
    options.InSampleSize = 2;
    Stream bitmap = Assets.Open("myimage.jpg");
    Android.Graphics.Bitmap bMap = Android.Graphics.BitmapFactory.DecodeStream(bitmap, null, options);
    iv.SetImageBitmap(bMap);
