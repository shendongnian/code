            int charactersPerRow = 14;
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-=~!@#$%^&*()_+,./;'[]\\<>?:\"{}|";
            int rows = (int)Math.Ceiling((decimal)chars.Length / (decimal)charactersPerRow);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            
            foreach (String FontName in DataHandler.GetFonts())
            {
                foreach (FontStyle Style in Enum.GetValues(typeof(FontStyle)))
                {
                    try
                    {
                        Bitmap map = new Bitmap(585, 559);
                        using (Graphics g = Graphics.FromImage(map))
                        {
                            // each char must fit into this size:
                            SizeF szF = new SizeF(map.Width / charactersPerRow, map.Height / rows);
                            // fallback font and size
                            int fntSize = 8;
                            Font fnt = new Font(FontName, fntSize, Style);
                            // figure out the largest font size that will fit into "szF" above:
                            bool smaller = true;
                            while (smaller)
                            {
                                Font newFnt = new Font(FontName, fntSize, Style);
                                for (int i = 0; i < chars.Length; i++)
                                {
                                    SizeF charSzF = g.MeasureString(chars[i].ToString(), newFnt);
                                    if (charSzF.Width > szF.Width || charSzF.Height > szF.Height)
                                    {
                                        smaller = false;
                                        break;
                                    }
                                }
                                if (smaller)
                                {
                                    if (fnt != null)
                                    {
                                        fnt.Dispose();
                                    }
                                    fnt = newFnt;
                                    fntSize++;
                                }
                            }
                            // draw each char at the appropriate location:
                            using (SolidBrush brsh = new SolidBrush(myColor))
                            {
                                for (int i = 0; i < chars.Length; i++)
                                {
                                    PointF ptF = new PointF(
                                        (float)(i % charactersPerRow) / (float)charactersPerRow * map.Width,
                                        ((float)((int)(i / charactersPerRow)) / (float)rows) * map.Height);
                                    g.DrawString(chars[i].ToString(), fnt, brsh, new RectangleF(ptF, szF), sf);
                                }
                            }
                            map.Save(OutputPath + "\\" + Style.ToString() + "_" + FontName + ".png");
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
