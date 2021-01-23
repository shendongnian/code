    [HttpPost]
    public ActionResult Edit2(WebSiteEF2017C.Models.Pictures_Tag p)
    {     
        using (var db = new thisModel(Session["org"].ToString())
        {
             p.Picture = db.Pictures.Where(z => z.ID == p.Picture_ID).FirstOrDefault();
             db.Pictures_Tags.Attach(p);
             db.Entry(p).State = EntityState.Modified;
             db.SaveChanges();
             return View(db.Pictures_Tags.Include(x => x.Picture)
                        .Where(n => n.Picture_ID == p.Picture_ID & n.ImageTag_ID == p.ImageTag_ID).FirstOrDefault());
            }
    }
