    [HttpPost]
            public RedirectToRouteResult Edit(Format format, [Bind(Prefix = "Tag")] IEnumerable<Guid> tags)
            {
                using (var dc = DataContextHelper.BoxTop)
                {
                     // remove old tags
                    foreach (var id in existing.Except(tags.EmptyIfNull()))
                        dc.FormatTag.DeleteOnSubmit(dc.FormatTag.Single(k => k.FormatID == format.FormatID && k.TagID == id));
    
                    // add new new tags
                    foreach (var id in tags.EmptyIfNull().Except(existing))
                        dc.FormatTag.InsertOnSubmit(new FormatTag() { FormatID = format.FormatID, TagID = id, });
    
                    dc.SubmitChanges();
                }
    
                return RedirectToAction("List");
            }
