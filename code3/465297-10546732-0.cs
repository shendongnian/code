        public ActionResult FormPostHandler()
        {
            try
            {
                // Process request
            }
            catch (Exception ex)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorNo = 1
                    });
                }
                else
                {
                    return View("ErrorView"); // add model for error
                }
            }
        }
