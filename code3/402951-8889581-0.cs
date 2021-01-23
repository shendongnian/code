    public class ImgBuffer<T> where T : Color32
    {
        public T[] buf;
        public int width;
        public int height;
        public ImgBuffer () {}
        public ImgBuffer (int w, int h)
        {
            buf = new T[w*h];
            width = w;
            height = h;
        }
    
        public void Mirror()
        {
            ImageTools.Mirror (ref buf, width, height);
        }
    }
