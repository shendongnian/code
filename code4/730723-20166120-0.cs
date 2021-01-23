       public Response<List<string>> UplaoadPostImage()
        {
            Response<List<string>> response = new Response<List<string>>();
            ResponseImage objtemp = new ResponseImage();
            List<string> objlist = new List<string>();
            try
            {
                HttpContextWrapper objwrapper = GetHttpContext(this.Request);
                HttpFileCollectionBase collection = objwrapper.Request.Files;
                if (collection.Count > 0)
                {
                    foreach (string file in collection)
                    {
                        
                        HttpPostedFileBase file1 = collection.Get(file);
                        Stream requestStream = file1.InputStream;
                        Image img = System.Drawing.Image.FromStream(requestStream);
                        //Image UserImage = objcommon.ResizeImage(img, 600, 600);
                        string UniqueFileName = file1.FileName;
                        img.Save(HttpContext.Current.Request.PhysicalApplicationPath + "UploadImage\\" + UniqueFileName, System.Drawing.Imaging.ImageFormat.Png);
                        objlist.Add(ConfigurationManager.AppSettings["ImagePath"] + UniqueFileName);
                        requestStream.Close();
                    }
                    response.Create(true, 0, Messages.FormatMessage(Messages.UploadImage_Sucess, ""), objlist);
                }
                else
                {
                    response.Create(false, 0, "File not found.", objlist);
                }
            }
            catch (Exception ex)
            {
                response.Create(false, -1, Messages.FormatMessage(ex.Message), objlist);
            }
            return response;
        }
        private HttpContextWrapper GetHttpContext(HttpRequestMessage request = null)
        {
            request = request ?? Request;
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]);
            }
            else if (HttpContext.Current != null)
            {
                return new HttpContextWrapper(HttpContext.Current);
            }
            else
            {
                return null;
            }
        }
