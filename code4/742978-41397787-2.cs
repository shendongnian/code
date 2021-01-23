        private readonly MyDataContext  _db = new MyDataContext ();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Event @event)
        {
            if (!ModelState.IsValid) { return View(@event); }
            _db.Entry(@event).State = EntityState.Modified;
            await _db.UpdateChildren(@event, x => x.Managers);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
