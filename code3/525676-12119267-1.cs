    class RgbToGray : ImageSource
    {
        private ImageSource m_src;
        public RgbToGray(ImageSource src)
        {
            m_src = src;
        }
        public void GetPixels(int x0, int y0, int width, int height, out Pixel[,] result)
        {
            // omitted: validate parameters
            Pixel[,] temp = ...;
            m_src.GetPixels(x0, y0, width, height, out temp);
            for (int y = y0; y < y0 + height; ++y)
            {
                for (int x = x0; x < x0 + width; ++x)
                {
                    result[y,x] = SomeCalculation(temp[y,x]);
                }
            }
        }
    };
