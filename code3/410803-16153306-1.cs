    [AcceptVerbs("POST")]
        public bool MethodWithoutParameters()
        {
            bool allow = true;
            if (allow)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [AcceptVerbs("POST")]
        public string MethodWithParameters(string id)
        {         
                return id + " i got it, man! ";           
        }
        [AcceptVerbs("GET")]
        public ActionResult GetSomeName()
        {
            var data = new { name = "TestName " };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs("POST")]
        public ActionResult PerformAction(FormCollection formCollection, Person model)
        {
            model.FirstName += "Well done! Form 1";
            return Json( model.FirstName);
        }
        [AcceptVerbs("POST")]
        public ActionResult PerformAction2(FormCollection formCollection, Person model)
        {
            model.FirstName += "Well don! Form 2";
            return Json(model.FirstName);
        }
        public JsonResult DeleteFile(string fileName)
        {
            var result = fileName + " has been deleted";
            return Json(result, JsonRequestBehavior.AllowGet);
        } 
