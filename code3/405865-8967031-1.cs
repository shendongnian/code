        [HttpPost, VerifyReportAccess]
        public ActionResult Refresh(Guid reportId)
        {
            string message;
            try
            {
                message = _publisher.RequestRefresh(reportId);
            }
            catch(Exception ex)
            {
                HttpContext.Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
                message = ex.Message;
            }
            return Json(message);
        }
