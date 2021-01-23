    public static bool IsImage(HttpPostedFileBase postedFile)
        {
    		try  {
                  using (var bitmap = new System.Drawing.Bitmap(postedFile.InputStream))
                        {                        
                                return !bitmap.Size.IsEmpty;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
    			}
    	}
