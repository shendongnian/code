     [HttpPost]
        public ActionResult MyAction ( MyModel model )
        {
            // called when a form is submitted
            return Json(new { success = true });
        }
