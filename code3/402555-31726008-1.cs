    private Bitmap retrieveBitmap()
        {
            Image image1 = null
            if (dt1.Rows.Count > 0)
            {
                byte[] imageData1 = null;
                if (dt1[0].Count > 0)
                {
                    if (!Information.IsDBNull(dt1.CopyToDataTable()[0].Item("File2")))
                    {
                        imageData1 = (byte[])dt1.CopyToDataTable()[0].Item("File2");
                    }
                }
                if ((imageData1 != null))
                {
                    if (isValidImage(imageData1))
                    {
                        using (MemoryStream ms = new MemoryStream(imageData1, 0, imageData1.Length))
                        {
                            ms.Write(imageData1, 0, imageData1.Length);
                            image1 = Image.FromStream(ms, true);
                        }
                        return image1;
                    }
                    else
                    {
                        // "Invalid image on server";
                        return null;
                    }
                }
            }
        }
