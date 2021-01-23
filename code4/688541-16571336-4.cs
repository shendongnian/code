    public class DomenaViewModel
    {
        public List<TLD> Tlds {get; set;} 
        public int SelectedTldId { get; set; }
        public IEnumerable<SelectListItem> TldItems
        {
            get { return new SelectList(Tlds, "TLDID", "Typ"); }
        }
        
        // irrelevant code omitted
    }
    [HttpGet]
    public ActionResult Create()
    {
        var model = new DomenaViewModel
          {
              Tlds = db.TLDs
          };
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(DomenaViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var tld = db.TLDs.Find(model.SelectedTldId); // assuming you're using DbContext
            if (tld != null)
            {
                // the mapping is best served in a different method, but we'll do it here for now
                var newDomena = new Domena
                  {
                      TLD = tld,
                      Cena = tld.Cena
                  }
                db.Domeny.Add(newDomena);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        viewModel.Tlds = db.TLDs;
        return View(viewModel);
    }
