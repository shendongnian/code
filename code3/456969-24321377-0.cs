            try
            {
                if (file != null && file.ContentLength > 0 && file.ContentLength<=10485760)
                {
                    var fileName = Path.GetFileName(file.FileName);                                        
                    
                    var path = Path.Combine(Server.MapPath("~/") + "HisloImages" + "\\", fileName);
                    
                    file.SaveAs(path);
                    #region MyRegion
                    ////save imag in Db
                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //    file.InputStream.CopyTo(ms);
                    //    byte[] array = ms.GetBuffer();
                    //} 
                    #endregion
                    return Json(JsonResponseFactory.SuccessResponse("Status:0 ,Message: OK"), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(JsonResponseFactory.ErrorResponse("Status:1 , Message: Upload Again and File Size Should be Less Than 10MB"), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                
             return Json(JsonResponseFactory.ErrorResponse(ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
