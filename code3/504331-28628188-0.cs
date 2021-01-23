    Word.Paragraph p = c2.Range.Paragraphs.Add(ref missing);
                    p.Range.Text = "your trip at " + sejour.Location;
                    SetTextColor(p.Range, Word.WdColor.wdColorWhite,0, p.Range.Text.Length - 1);
                    SetTextSize(p.Range, (float)14, 0, p.Range.Text.Length - 1);
                    SetTextSize(p.Range, (float)16, p.Range.Text.Length - 2 - sejour.Location.Length, sejour.Location.Length);
    
            public void SetTextColor( Word.Range range, Microsoft.Office.Interop.Word.WdColor color, int start, int length)
            {
                Word.Range rng = range;
                rng.Start = range.Start + start;
                rng.End = range.Start + start + length;
                rng.Font.Color = color;
            }
            public void SetTextSize(Word.Range range, float size, int start, int length)
            {
    
                Word.Range rng = range;
                rng.Start = range.Start + start;
                rng.End = range.Start + start + length;
                rng.Font.Size = size;
            }
