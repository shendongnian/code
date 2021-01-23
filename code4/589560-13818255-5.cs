         [HttpPost]
        public JsonResult DeleteAttachment(int id)
        {
            DeleteAttachment(id);
            return Json("ok");
        }
