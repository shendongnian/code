           private void DgNewItem_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        
           {
          
          int strt = 0;
            
          int cnt = -1;
           
          int idx = -1;
           
            if ((((e.RowIndex >= 0) && (e.ColumnIndex >= 0))))
           
           {
                       
             e.Handled = true;
             
        e.PaintBackground(e.CellBounds, true);
               
               
                 **//string sw = GetSearchWord(e.ColumnIndex);**
              
                if (!string.IsNullOrEmpty(sw))
                {
                    string val = e.FormattedValue.ToString();
                    int sindx = val.ToLower().IndexOf(sw.ToLower());
                    if ((sindx >= 0))
                    {
                        while (strt != -1)
                        {
                            strt = val.ToLower().IndexOf(sw.ToLower(), idx + 1);
                            cnt += 1;
                            idx = strt;
                            //int numberOfTrues = Regex.Matches(val, sw).Count;
                            // the highlite rectangle
                            if (strt != -1)
                            {
                                Rectangle hl_rect = new Rectangle();
                                hl_rect.Y = (e.CellBounds.Y + 2);
                                hl_rect.Height = (e.CellBounds.Height - 5);
                                // find the size of the text before the search word
                                // and the size of the search word
                                string sBefore = val.Substring(0, idx);
                                string sWord = val.Substring(idx, sw.Length);
                                Size s1 = TextRenderer.MeasureText(e.Graphics, sBefore, e.CellStyle.Font, e.CellBounds.Size);
                                Size s2 = TextRenderer.MeasureText(e.Graphics, sWord, e.CellStyle.Font, e.CellBounds.Size);
                                // adjust the widths to make the highlite more accurate
                                if ((s1.Width > 5))
                                {
                                    hl_rect.X = (e.CellBounds.X
                                    + (s1.Width - 5));
                                    hl_rect.Width = (s2.Width - 6);
                                }
                                else
                                {
                                    hl_rect.X = (e.CellBounds.X + 2);
                                    hl_rect.Width = (s2.Width - 6);
                                }
                                // use darker highlight when the row is selected
                                SolidBrush hl_brush;
                                if (((e.State & DataGridViewElementStates.Selected)
                                != DataGridViewElementStates.None))
                                {
                                    hl_brush = new SolidBrush(Color.DarkGoldenrod);
                                }
                                else
                                {
                                    hl_brush = new SolidBrush(Color.Violet);
                                }
                                // paint the background behind the search word
                                e.Graphics.FillRectangle(hl_brush, hl_rect);
                                hl_brush.Dispose();
                            }
                        }
                    }
                }
                // paint the content as usual
                e.PaintContent(e.CellBounds);
            }
        }
