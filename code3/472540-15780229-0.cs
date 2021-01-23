       //some code to declare variables
        if (headerImage != null)
        {
            if (!String.IsNullOrEmpty(headerImage.ContentType))
            {
                headerImageContentType = imageHelper.IsValidImageType(headerImage.ContentType);
                if (headerImageContentType)
                {
                    resizedHeaderImage = imageHelper.ResizeImage(headerImage.InputStream);
                }
                else
                {
                    ViewBag.ReturnMessage="<span style='color:red'> Please Upload an image* file less than 2GB.</span>";
                    return View();
                }
            }
        }
        if (footerImage != null)
        {
            if (!String.IsNullOrEmpty(footerImage.ContentType))
            {
                footerImageContentType = imageHelper.IsValidImageType(footerImage.ContentType);
                if (footerImageContentType)
                {   
                    resizedFooterImage = imageHelper.ResizeImage(footerImage.InputStream);
                }
                else
                {
                    ViewBag.ReturnMessage="<span style='color:red'>Please Upload an image* file less than 2GB.</span>";
                    return View();
                }
            }
        }
        if (P24DataPrincipal.CurrentIdentity != null)
        {
            if (resizedHeaderImage != null || resizedFooterImage != null)
            {
              //add to DB code
                    ViewBag.ReturnMessage="<span style='color:green'>Image(s) Uploaded Successfully.</span>";
                    return View();
            }
            else
            {
                ViewBag.ReturnMessage="<span style='color:red'>Upload atleast 1 image file.</span>";
                return View();
            }
        }
