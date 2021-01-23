    public class MyClass
    {
        private Bitmap _myImage;
        public void InitializeBMPObjects()
        {
            _myImage = new Bitmap(320, 226); 
        }
        public void pushPixels()
        {
            Graphics g = Graphics.FromImage(_myImage);
            //Do some graphics stuff....
        }
    }
