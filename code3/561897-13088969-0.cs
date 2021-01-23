            private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
            {
                ListView lv = (ListView)sender;
                int widthDifference = Math.Abs(lv.Columns[ e.ColumnIndex].Width - e.NewWidth);
                if( widthDifference>2)
                {
                    int maxWidth = 0;
                    Graphics g = lv.CreateGraphics();
                    for(int i = 0;i<lv.Items.Count;i++) 
                    {
                        string text = string.Empty;
                        if (e.ColumnIndex == 0)
                        {
                            text = lv.Items[i].Text;
                        }
                        else
                        {
                            text = lv.Items[i].SubItems[e.ColumnIndex - 1].Text;
                        }
                        SizeF sizeF = g.MeasureString(text, lv.Font);
                        if (maxWidth < (int)(sizeF.Width + 0.5))
                            maxWidth = (int)(sizeF.Width + 0.5);
                    }
                    g.Dispose();
                    e.NewWidth = maxWidth;
                }
            }
