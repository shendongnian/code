        [HttpPost]
        public ActionResult Create(PrintJob printjob)
        {
            if (ModelState.IsValid)
            {
                printjob.UpdatePrintTime();
                db.PrintJobs.Add(printjob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ...
            return View(printjob);
        }
        public ActionResult Edit(int id = 0)
        {
            PrintJob printjob = db.PrintJobs.Find(id);
            if (printjob == null)
            {
                return HttpNotFound();
            }
            printjob.UpdatePrintString();
            ...
            return View(printjob);
        }
        [HttpPost]
        public ActionResult Edit(PrintJob printjob)
        {
            if (ModelState.IsValid)
            {
                printjob.UpdatePrintTime();
                db.Entry(printjob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            printjob.UpdatePrintString();
            ...
            return View(printjob);
        }
