        private void OutLine_Box(SpriteBatch sbatch, Rectangle rect)
        {
            List<Vector2> pixels = new List<Vector2>();
            for (int x = rect.X; x < rect.X + rect.Width; x++)
            {
                for (int y = rect.Y; y < rect.Y + rect.Height; y++)
                {
                    if (y == rect.Y || y == rect.Y + rect.Height - 1)
                        pixels.Add(new Vector2(x, y));
                    if (x == rect.X || x == rect.X + rect.Width - 1)
                        pixels.Add(new Vector2(x, y));
                }
            }
            foreach (Vector2 v in pixels)
                sbatch.Draw(PixelTexture, v, OutLineColor);
        }
