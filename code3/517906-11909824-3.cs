        public ActionResult GetMagician(string userName)
        {
           return Json(new { Name="Jon", Job="Stackoverflow Answering" },
                                      JsonRequestBehavior.AllowGet);
        }
