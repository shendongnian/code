        public static void ScaleLabel(Label label, float stepSize = 0.5f)
        {
            //decrease font size if label width is smaller than text size
            if (label.Width < getLblTextWidth(label).Width)
            {
                while (label.Width < getLblTextWidth(label).Width)
                {
                    label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
                }
            }
            //increase font size if label width is bigger than text size
            else if ((label.Width - 5) > getLblTextWidth(label).Width)
            {
                while ((label.Width - 5) > getLblTextWidth(label).Width)
                {
                    var font = new Font(label.Font.FontFamily, label.Font.Size + stepSize, label.Font.Style);
                    //when increasing the font size dont make text higher than label
                    if (TextRenderer.MeasureText(label.Text, font).Height > label.Height)
                        break;
                    label.Font = font;
                }
            }
            //decrease font size if exceeding label height 
            if (getLblTextWidth(label).Height > label.Height)
            {
                while (getLblTextWidth(label).Height > label.Height)
                {
                    if (label.Font.Size - stepSize < 0)
                        break;
                    label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
                }
            }
            Size getLblTextWidth(Label l)
            {
                return TextRenderer.MeasureText(l.Text, new Font(l.Font.FontFamily, l.Font.Size, l.Font.Style));
            }
        }
