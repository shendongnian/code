    class RgbToGray : ImageSource
    {
        private ImageSource m_src;
        public RgbToGray(ImageSource src)
        {
            m_src = src;
        }
        public void GetPixels(int x0, int y0, int rectWidth, int rectHeight, out Pixel[,] result)
        {
            // omitted: validate parameters
            Pixel[,] temp = new Pixel[rectHeight, rectWidth];
            m_src.GetPixels(x0, y0, rectWidth, rectHeight, out temp);
            for (int y = y0; y < y0 + rectHeight; ++y)
            {
                for (int x = x0; x < x0 + rectWidth; ++x)
                {
                    result[y,x] = SomeCalculation(temp[y,x]);
                }
            }
        }
    };
