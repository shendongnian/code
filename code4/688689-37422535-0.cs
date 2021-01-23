    for (byte i = 0; i < pages.Count(); i++)
            {
                PdfPage oPage = new PdfPage();
                doc.Pages.Add(oPage);
                using (var xgr = XGraphics.FromPdfPage(oPage))
                {
                    using (var bm = pages[i])
                    {
                        using (var img = XImage.FromGdiPlusImage(bm))
                        {
                            doc.Pages[i].Width = XUnit.FromPoint(ximg.Size.Width);
                            doc.Pages[i].Height = XUnit.FromPoint(ximg.Size.Height);
                            xgr.DrawImage(ximg, 0, 0, img.Size.Width, img.Size.Height);
                        }
                    }
                }
            }
