    public class TestClass
    {
        public BitmapFactory BitmapFactory { get; set; }
        public Bitmap Bitmap { get { return this.BitmapFactory.Bitmap; } }
    }
    
    public interface IBitmapFactory
    {
        Bitmap Bitmap { get; }
    }
    
    public class BitmapFactory : IBitmapFactory
    {
        public Bitmap Bitmap { get; private set; }
    
        public BitmapFactory(Bitmap value)
        {
            this.Bitmap = value;
        }
    
        public BitmapFactory(BitmapImage value)
        {
            this.Bitmap = ConvertBitmapImageToBitmap(value);
        }
    
        public BitmapFactory(WriteableBitmap value)
        {
            this.Bitmap = ConvertWriteableBitmapToBitmap(value);
        }
    
        private Bitmap ConvertWriteableBitmapToBitmap(WriteableBitmap value)
        {
            //do work here
            return null;
        }
    
        private Bitmap ConvertBitmapImageToBitmap(BitmapImage value)
        {
            //do work here
            return null;
        }
    }
