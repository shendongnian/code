    public class ImgBuffer<T>
    {
        public T[] buf;
        public int width;
        public int height;
        public void Mirror()
        {
            ImageTools.Mirror(ref buf, width, height);
        }
    }
