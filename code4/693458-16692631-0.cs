        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            string text = "this is distribute";
            Rectangle displayRectangle = new Rectangle(new Point(40, 40), new Size(400, 80));
            e.Graphics.DrawRectangle(Pens.Black, displayRectangle);
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
            format1.LineAlignment = StringAlignment.Center;
            format1.Alignment = StringAlignment.Near;
            // SetMeasurableCharacterRanges() can only handle 32 regions max at a time!
            // The below workaround simply measures each character separately:
            RectangleF rcF = (RectangleF)displayRectangle;
            List<Region> regions = new List<System.Drawing.Region>();
            for (int i = 0; i < text.Length; i++)
            {
                format1.SetMeasurableCharacterRanges(new CharacterRange[] {new CharacterRange(i, 1)});    
                regions.AddRange(e.Graphics.MeasureCharacterRanges(text, this.Font, rcF, format1));
            }
            
            RectangleF minBounds = regions[0].GetBounds(e.Graphics);
            RectangleF maxBounds = regions[regions.Count - 1].GetBounds(e.Graphics);
            float ratio = (float)displayRectangle.Width / (float)((maxBounds.X + maxBounds.Width) - minBounds.X);
            for(int i = 0; i < regions.Count; i++)
            {
                Region region = regions[i];
                RectangleF boundsF = region.GetBounds(e.Graphics);
                PointF ptF = new PointF(displayRectangle.X + (int)((boundsF.Left - minBounds.X) * ratio), (int)boundsF.Top);
                e.Graphics.DrawString(text.Substring(i, 1), this.Font, Brushes.Black, ptF);
            }
        }
