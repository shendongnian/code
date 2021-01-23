        public static void ScaleLabel(Label label, float stepSize = 0.5f)
        {
            //decrease font size if label width is smaller than text size
            if (label.Width < getLblTextSize(label).Width)
            {
                while (label.Width < getLblTextSize(label).Width)
                {
                    label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
                }
            }
            //increase font size if label width is bigger than text size
            else if (label.Width > getLblTextSize(label).Width)
            {
                while (label.Width > getLblTextSize(label).Width)
                {
                    var font = new Font(label.Font.FontFamily, label.Font.Size + stepSize, label.Font.Style);
                    var nextSize = TextRenderer.MeasureText(label.Text, font);
                    //when increasing the font size dont make text higher than label
                    if (nextSize.Height > label.Height)
                        break;
                    //when increasing the font size dont make text wider than label
                    if (nextSize.Width > label.Width)
                        break;
                    label.Font = font;
                }
            }
            //decrease font size if exceeding label height 
            if (getLblTextSize(label).Height > label.Height)
            {
                while (getLblTextSize(label).Height > label.Height)
                {
                    if (label.Font.Size - stepSize < 0)
                        break;
                    label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
                }
            }
            Size getLblTextSize(Label l)
            {
                return TextRenderer.MeasureText(l.Text, new Font(l.Font.FontFamily, l.Font.Size, l.Font.Style));
            }
        }
