        [HttpPost]
        public RedirectToRouteResult Edit(IEnumerable<Guid> tags)
        {
            using (var dc = new MyDataContext())
            {
                var existing = dc.Tag
                    .Select(i => i.TagID)
                    .ToList();
                // remove old
                foreach (var id in existing.Except(tags.EmptyIfNull()))
                    dc.Tag.DeleteOnSubmit(dc.Tag.Single(k => k.TagID == id);
                // add new
                foreach (var id in tags.EmptyIfNull().Except(existing))
                    dc.Tag.InsertOnSubmit(new tTag() { TagID = id, });
                dc.SubmitChanges();
            }
            return RedirectToAction("List");
        }
   
