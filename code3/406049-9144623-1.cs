        public class Position
        {
            public int bestRow { get; set; }
            public int bestCol { get; set; }
            public double bestSAD { get; set; }
            public Position(int row, int col, double sad)
            {
                bestRow = row;
                bestCol = col;
                bestSAD = sad;
            }
        }
        Position element_position = new Position(0, 0, double.PositiveInfinity);
        Position ownSearch(Bitmap search, Bitmap template) {
            Position position = new Position(0,0,double.PositiveInfinity);
            double minSAD = double.PositiveInfinity;
            
            // loop through the search image
            for (int x = 0; x <= search.PhysicalDimension.Width - template.PhysicalDimension.Width; x++)
            {
                for (int y = 0; y <= search.PhysicalDimension.Height - template.PhysicalDimension.Height; y++)
                {
                    position_label2.Content = "Running: X=" + x + "  Y=" + y;
                    double SAD = 0.0;
                    // loop through the template image
                    for (int i = 0; i < template.PhysicalDimension.Width; i++)
                    {
                        for (int j = 0; j < template.PhysicalDimension.Height; j++)
                        {
                            int r = Math.Abs(search.GetPixel(x + i, y + j).R - template.GetPixel(i, j).R);
                            int g = Math.Abs(search.GetPixel(x + i, y + j).G - template.GetPixel(i, j).G);
                            int b = Math.Abs(search.GetPixel(x + i, y + j).B - template.GetPixel(i, j).B);
                            int a = template.GetPixel(i, j).A;
                            SAD = SAD + ((r + g + b)*a/255 );
                        }
                    }
                    // save the best found position 
                    if (minSAD > SAD)
                    {
                        minSAD = SAD;
                        // give me VALUE_MAX
                        position.bestRow = x;
                        position.bestCol = y;
                        position.bestSAD = SAD;
                    }
                }
            }
            return position;
        }
