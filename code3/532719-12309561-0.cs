    public ActionResult GetEisReportRedirect()
            {
                string url =  eisReportBLLHdl.DoGetEisReportRedirect(  );
    
                return View( url );// i was passing url here to the view
            }
