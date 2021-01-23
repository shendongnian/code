        private static void DrawBrokenLine(PointF[] line, string text, Graphics g, Font font)
        {
            float lastOverlap = 0;
            for (int index = 0; index < line.Length - 1; index++)
            {
                float distance = distanceBetween(line[index], line[index + 1]);
                float angleOfLines = 180;
                if (index < line.Length - 2)
                {
                    angleOfLines = angleBetweenLines(line[index], line[index + 1], line[index + 2]);
                }
                if (text.Length > 0)
                {
                    SizeF textSize = g.MeasureString(text, font);
                    float overlap = 0;
                    if (angleOfLines < 180)
                    {
                        if (angleOfLines <= 90)
                        {
                            overlap = (textSize.Height / 1.5f) / (
                                Convert.ToSingle(Math.Tan((angleOfLines / 2) * Math.PI / 180))
                                );
                        }
                        else
                        {
                            overlap = Convert.ToSingle(
                                Math.Sin(angleOfLines * Math.PI / 180) * (textSize.Height / 1.5f));
                        }
                    }
                    for (int cIndex = text.Length; cIndex >= 0; cIndex--)
                    {
                        textSize = g.MeasureString(text.Substring(0, cIndex).Trim(), font);
                        if (textSize.Width <= distance - overlap - lastOverlap)   //notice the subtraction of overlap
                        {
                            float rotation = angleBetween(line[index], line[index + 1]);
                            g.TranslateTransform(line[index].X, line[index].Y);
                            g.RotateTransform(rotation);
                            g.DrawString(text.Substring(0, cIndex).Trim(), font, new SolidBrush(Color.Black),
                                new PointF(lastOverlap, -textSize.Height));
                            g.RotateTransform(-rotation);
                            g.TranslateTransform(-line[index].X, -line[index].Y);
                            text = text.Remove(0, cIndex);
                            break;
                        }
                    }
                    lastOverlap = overlap;
                }
                else
                    break;
            }
        }
        private static float angleBetweenLines(PointF A, PointF B, PointF C)
        {
            float angle1 = 360 - angleBetween(A, B);
            float angle2 = 360 - angleBetween(B, C);
            if (angle1 < 0)
                angle1 += 360;
            if (angle2 < 0)
                angle2 += 360;
            float delta = 180 + angle1 - angle2;
            if (delta < 0)
                delta += 360;
            if (delta > 360)
                delta -= 360;
            return delta;
        }
