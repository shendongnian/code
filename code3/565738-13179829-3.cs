    [HttpPost]
        public RedirectToRouteResult Edit(Format format, IEnumerable<Guid> tags)
        {
            using (var dc = new MyDataContext())
            {
                var existing = dc.Format
                    .Single(k => k.FormatID == format.FormatID)
                    .FormatTag
                    .Select(i => i.TagID)
                    .ToList();
                // remove old
                foreach (var id in existing.Except(tags.EmptyIfNull()))
                    dc.FormatTag.DeleteOnSubmit(dc.FormatTag.Single(k => k.FormatID == format.FormatID && k.TagID == id));
                // add new
                foreach (var id in tags.EmptyIfNull().Except(existing))
                    dc.FormatTag.InsertOnSubmit(new FormatTag() { FormatID = format.FormatID, TagID = id, });
                dc.SubmitChanges();
            }
            return RedirectToAction("List");
        }
    }
