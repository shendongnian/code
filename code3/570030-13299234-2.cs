        [HttpPost]
        public JsonResult UpdateLists(IDictionary<string, string> PreAcceptList, IDictionary<string, string> PostAcceptList)
        {
            return Json("List(s) updated successfully.");
        }
