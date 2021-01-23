        private static void DrawBrokenLine(PointF[] line, string text, Graphics g, Font font)
        {
            for (int index = 0; index < line.Length - 1; index++)
            {
                float distance = distanceBetween(line[index], line[index + 1]);
                if (text.Length > 0)
                {
                    for (int cIndex = text.Length; cIndex >= 0; cIndex--)
                    {
                        SizeF textSize = g.MeasureString(text.Substring(0, cIndex).Trim(), font);
                        if (textSize.Width <= distance)
                        {
                            float rotation = angleBetween(line[index], line[index + 1]);
                            g.TranslateTransform(line[index].X, line[index].Y);
                            g.RotateTransform(rotation);
                            g.DrawString(text.Substring(0, cIndex).Trim(), font, new SolidBrush(Color.Black),
                                new PointF(0, -textSize.Height));
                            g.RotateTransform(-rotation);
                            g.TranslateTransform(-line[index].X, -line[index].Y);
                            text = text.Remove(0, cIndex);
                            break;
                        }
                    }
                }
                else
                    break;
            }
        }
