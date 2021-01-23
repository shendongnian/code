    public class UploadFileViewModel
        {
            public HttpPostedFileBase postedFile { get; set; }
    
            public  bool IsImage()
            {
        		try  {
                      using (var bitmap = new System.Drawing.Bitmap(this.postedFile.InputStream))
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
        }
