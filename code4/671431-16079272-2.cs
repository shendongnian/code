        [HttpPost]
        public ActionResult SendAttachment(SomeViewModel model, HttpPostedFileBase attachment)
        {
            return View();
        }
        public class SomeViewModel  
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
