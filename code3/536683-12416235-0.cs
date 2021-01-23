    // this is your thread method
    // it touches no UI elements, just loads files and passes them to the main thread
    private void LoadFiles(List<string> filenames) {
       foreach (var file in filenames) {
          var key = filename.Replace(...);
          var largeBmp = Image.FromFile(...);
          var smallBmp = Image.FromFile(...);
          this.Invoke(new AddImagesDelegate(AddImages), key, largeBmp, smallBmp);
       }
    }
    // this executes on the main (UI) thread    
    private void AddImages(string key, Bitmap large, Bitmap small) {
       // add bitmaps to listview
       files.SmallImageList.Images.Add(key, small);
       files.LargeImageList.Images.Add(key, large);
    }
    private delegate AddImagesDelegate(string key, Bitmap large, Bitmap small);
