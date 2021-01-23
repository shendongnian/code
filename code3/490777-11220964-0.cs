            int lastSpace = 0;
            int nextSpace = s.IndexOf(' ', lastSpace + 1);
            float width = 0;
            float totalWidth = 0;
            float maxWidth = 200;
            while (nextSpace >= 0)
            {
                string piece = s.Substring(lastSpace, nextSpace - lastSpace);
                width = g.MeasureString(piece, this.Font).Width;
                if (totalWidth + width < maxWidth)
                {
                    sb.Append(piece);
                    totalWidth += width;
                }
                else
                {
                    sb.AppendLine(piece);
                    totalWidth = 0;
                }
                lastSpace = nextSpace;
                nextSpace = s.IndexOf(' ', lastSpace + 1);
            }
            MessageBox.Show(sb.ToString());
