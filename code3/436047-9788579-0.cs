        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                Qr qr = fqr.FindQr(item.QR, db);
                // update somewhere here
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SetID = new SelectList(db.Sets, "SetID", "Name", item.SetID);
            return View(item);
        }
    public class FindQrs
    {
         public Qr FindQr(string qr, SESOContext db)  // pass in the db context
         {
              List<Qr> qrList = db.Qrs.ToList<Qr>();
              Qr foundQr = qrList.Find(delegate(Qr qrDel) { return qrDel.Value == qr; });
              return foundQr;
         }
    }
