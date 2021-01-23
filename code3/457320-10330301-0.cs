    public void Load(string fileName) 
    {
        using(Stream BitmapStream = System.IO.File.Open(fileName,System.IO.FileMode.Open ))
        {
             Image img = Image.FromStream(BitmapStream);
             mBitmap=new Bitmap(img);
             //...do whatever
        }
    }
