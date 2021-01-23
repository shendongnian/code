    using MvcApplication.Models.Home;
    using System;
    using System.Web.Mvc;
    
    namespace MvcApplication.Controllers
    {
        public class SharepointController : MvcBoostraBaseController
        {
            [HttpPost]
            public ActionResult Upload(FormCollection form)
            {
                try
                {
                    SharepointModel sharepointModel = new SharepointModel();
                    return Json(sharepointModel.UploadMultiFiles(Request, Server), JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return ThrowJSONError(ex);
                }
            }
    
            public ActionResult Download(string ServerUrl, string RelativeUrl)
            {
                try
                {
                    SharepointModel sharepointModel = new SharepointModel();
                    return Json(sharepointModel.DownloadFiles(), JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return ThrowJSONError(ex);
                }
            }
        }
    }
