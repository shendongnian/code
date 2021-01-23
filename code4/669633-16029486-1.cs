        [WebGet(UriTemplate = "/documents/{id}")]
        public ActionResult GetDocument(int id)
        {
            using(var context = new CorrespondenceDataContext())
            {
                var item = context.DocumentsPDFs.Find(id);
                return File(item.Document, "application/pdf", "Document-" + id);
            }
        }
