        public ActionResult Validate(string prop3)
        {
            string prop3Val = Request.QueryString["item.prop3"].ToString();
            //your operations with prop3Val
            return Json(prop3Val, JsonRequestBehavior.AllowGet);
        }
