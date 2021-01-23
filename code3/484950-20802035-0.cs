    public static bool IsImage(this HttpPostedFileBase postedFile)
    {
		try  {
                    using (var bitmap = new System.Drawing.Bitmap(postedFile.InputStream))
                    {
                        if(bitmap.Size.IsEmpty)
                        {
                            return false;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
			}
	}
