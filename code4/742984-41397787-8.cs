        // POST: Admin/Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Event @event)
        {
            if (!ModelState.IsValid) { return View(@event); }
            await _db.AddOrUpdate(@event);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
