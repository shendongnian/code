     public string MakeJPGFromDataTable(DataTable dt)
        {
            Font fnt = new System.Drawing.Font("verdana", 10,FontStyle.Bold);
            string strPath = Path.GetTempPath();
            string strJPG = "";
            strPath += "Publisher";
            Directory.CreateDirectory(strPath);
            Graphics grfx = CreateGraphics();
            float nWdBMP = 0;
            float nHtBMP = 0;
            var TalleststringLength = dt.AsEnumerable().Max(row => row.ItemArray.Max(x => grfx.MeasureString(x.ToString(), fnt).Height));
            var longeststringLength = dt.AsEnumerable().Max(row => row.ItemArray.Max(x => grfx.MeasureString(x.ToString(), fnt).Width));
            //string ss =  dt.Columns[1].ToString();
            //int[] nColHeaderLengths = (from z in new int[7] { 0, 1, 2, 3, 4, 5, 6 } select dt.Columns.Cast<DataColumn>().Max(dc => (int)grfx.MeasureString(dt.Columns[z].ToString(), fnt).Width)).ToArray();
            //int[] nColWidths = (from z in new int[7] { 0, 1, 2, 3, 4, 5, 6 } select dt.AsEnumerable().Max(row => (int)grfx.MeasureString(row.ItemArray[z].ToString(), fnt).Width)).ToArray();
            var xx = (from x in dt.Columns.Cast<DataColumn>() select x.Ordinal).ToArray();
            var nColWidths = (from z in (xx)
                               select dt.AsEnumerable().Max(row =>
                                   (grfx.MeasureString(row.ItemArray[z].ToString(), fnt).Width >
                                   grfx.MeasureString(dt.Columns[z].ToString(), fnt).Width)
                                   ? grfx.MeasureString(row.ItemArray[z].ToString(), fnt).Width
                                   : grfx.MeasureString(dt.Columns[z].ToString(), fnt).Width)
                ).ToArray();
            nWdBMP = nColWidths.Sum();
            nHtBMP = TalleststringLength * (dt.Rows.Count + 1);
            int xPos = 0;
            int yPos = 0;
            int nMargin = 10;
            Bitmap mapMem = new Bitmap((int)nWdBMP + (nMargin * (dt.Columns.Count + 1)), (int)nHtBMP);
            Graphics grfxMem = Graphics.FromImage(mapMem);
            grfxMem.SmoothingMode = SmoothingMode.HighQuality;
            grfxMem.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grfxMem.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grfxMem.CompositingQuality = CompositingQuality.GammaCorrected;
            grfxMem.FillRectangle(lgBackgroundBrush,0,0,mapMem.Width,mapMem.Height);
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                grfxMem.DrawString(dt.Columns[j].ToString(), fnt, lgFontBrush, xPos, yPos);
                //xPos += (int)grfx.MeasureString(dt.Columns[j].ToString(), fnt).Width;
                xPos += (int)nColWidths[j] + nMargin;
            }
            xPos = 0;
            yPos += (int)TalleststringLength;
            grfxMem.DrawLine(pen, new Point(0, yPos), new Point((int)mapMem.Width, yPos));
            //foreach (DataRow dr in dt.Rows)
            //{
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        grfxMem.DrawString(dr[j].ToString(), fnt, Brushes.Blue, xPos, yPos);
            //        xPos += (int)nColWidths[j] + nMargin;
            //    }
            //    xPos = 0;
            //    yPos += (int)TalleststringLength;
            //}
            int s = 0;
            Func<object, bool> too_much_where = delegate(object itemCurrent)
            {
                grfxMem.DrawString(itemCurrent.ToString(), fnt, lgFontBrush, xPos, yPos);
                xPos += (int)nColWidths[s++] + nMargin;
                if (s >= dt.Columns.Count)
                {
                    //Know what this determines the end of every row
                    s = 0;
                    xPos = 0;
                    yPos += (int)TalleststringLength;
                    grfxMem.DrawLine(pen, new Point(0, yPos), new Point((int)mapMem.Width, yPos));
                }
                return false;
            };
            //var sizzeler = (from dr in dt.AsEnumerable()
            //                let drItems = (from itemCurrent in dr.ItemArray select itemCurrent)
            //                               from item in drItems
            //                                where too_much_where(item)
            //                    select new
            //                    {
            //                        z = true,
            //                    }
            //                ).ToArray();
            var sizzeler = (from dr in dt.AsEnumerable()
                            where (dr.ItemArray.Where(itemCurrent => too_much_where(itemCurrent)).Count() == 0)
                            select new
                            {
                                z = true,
                            }
                            ).ToArray();
            s = 0;
            for (int j = 0; j < nColWidths.Length; j ++)
            {
                grfxMem.DrawLine(pen, new Point(s, 0), new Point(s, (int)mapMem.Height));
                s += (int)(nColWidths[j] + nMargin );
            }
            s = mapMem.Width-1;
            grfxMem.DrawRectangle(pen, new Rectangle(0, 0, mapMem.Width - 1, mapMem.Height - 1));
            s = 0;
            grfx.DrawImage(mapMem, (float)10.0, (float)10.0);
            grfx.Dispose();
            return strJPG;
        }
