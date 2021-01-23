    [HttpPost]
        public ActionResult Save(IEnumerable<HttpPostedFileBase> files)
        {
            if ( files != null )
            {
                // do something fancy with the files
            }
            return new HttpStatusCodeResult(200);
        }
