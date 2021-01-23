    internal class SevenSegmentDisplay
    {
        private int a, b, c, d, e, f, g;
        private readonly int[,] numbers;
        public SevenSegmentDisplay()
        {
            numbers = new[,] {
                  /* Format is A - G, see: 
                   * https://en.wikipedia.org/wiki/Seven-segment_display
                   */
                  // 0
                  {1, 1, 1, 1, 1, 1, 0},
                  // 1
                  {0, 1, 1, 0, 0, 0, 0},
                  // 2
                  {1, 1, 0, 1, 1, 0, 1},
                  // 3
                  {1, 1, 1, 1, 0, 0, 1},
                  // 4
                  {0, 1, 1, 0, 0, 1, 1},
                  // 5
                  {1, 0, 1, 1, 0, 1, 1},
                  // 6
                  {1, 0, 1, 1, 1, 1, 1},
                  // 7
                  {1, 1, 1, 0, 0, 0, 0},
                  // 8
                  {1, 1, 1, 1, 1, 1, 1},
                  // 9
                  {1, 1, 1, 1, 0, 1, 1}
            };
            // Initialize each segment to 0 (black)
            a = 0;
            b = 0;
            c = 0;
            d = 0;
            e = 0;
            f = 0;
            g = 0;
        }
        private void Update(IList<int> i)
        {
            // Update each segment
            a = i[0];
            b = i[1];
            c = i[2];
            d = i[3];
            e = i[4];
            f = i[5];
            g = i[6];
        }
        public void Update(int i)
        {
            Update(IntToSevenSegment(i));
        }
        private int[] IntToSevenSegment(int i)
        {
            int[] temp = new int[7];
            for (int counter = 0; counter < 7; counter++)
                temp[counter] = numbers[i, counter];
            return temp;
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D texture, int x, int y, Color on, Color off)
        {
            // Texture should be a white square, to handle the drawing of each segment.
            // Handle each segment A - G and draw them according to their positions depending on the texture size.
            Rectangle a = new Rectangle(x + texture.Width, y, texture.Width*2, texture.Height);
            Rectangle b = new Rectangle(x + texture.Width*3, y + texture.Height, texture.Width, texture.Height*2);
            Rectangle c = new Rectangle(x + texture.Width*3, y + texture.Height*4, texture.Width, texture.Height*2);
            Rectangle d = new Rectangle(x + texture.Width, y + texture.Height*6, texture.Width*2, texture.Height);
            Rectangle e = new Rectangle(x, y + texture.Height*4, texture.Width, texture.Height*2);
            Rectangle f = new Rectangle(x, y + texture.Height, texture.Width, texture.Height*2);
            Rectangle g = new Rectangle(x + texture.Width, y + texture.Height*3, texture.Width*2, texture.Height);
            spriteBatch.Draw(texture, a, this.a == 1 ? on : off);
            spriteBatch.Draw(texture, b, this.b == 1 ? on : off);
            spriteBatch.Draw(texture, c, this.c == 1 ? on : off);
            spriteBatch.Draw(texture, d, this.d == 1 ? on : off);
            spriteBatch.Draw(texture, e, this.e == 1 ? on : off);
            spriteBatch.Draw(texture, f, this.f == 1 ? on : off);
            spriteBatch.Draw(texture, g, this.g == 1 ? on : off);
        }
    }
