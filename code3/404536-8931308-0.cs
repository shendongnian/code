    public abstract class ImageFilter
    {
        protected abstract void ApplyFilter(byte[,] imageData);
        public Bitmap Apply(Bitmap image)
        {
            // lockbits etc
            ApplyFilter(imageData);
            // unlockbits
        }
    }
    public class MyFilter : ImageFilter
    {
        protected override ApplyFilter(byte[,] imageData)
        {
            // work on the bits
        }
    }
    Bitmap newBitmap = new MyFilter().Apply(oldBitmap);
