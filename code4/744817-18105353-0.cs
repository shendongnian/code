        //
        // GET: /Book/Search?query=
        public ActionResult Search(string query)
        {
            return RedirectToAction("Detail", new { id = query });
        }
        //
        // GET: /Book/Detail/id
        public ActionResult Detail(string id)
