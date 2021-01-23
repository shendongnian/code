    if (ModelState.IsValid)
    {
        page.IsPublished = !string.IsNullOrEmpty(frm["BtnPublish"]);
        _db.Entry(page).State = EntityState.Modified;
        _db.SaveChanges();
        var ph = pageHistoryBuilder.Build(page);
        ph.SaveChanges();
    // and so long
    }
