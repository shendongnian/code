    [HttpPost]
    public ActionResult Create(A a){
       B b = db.Bs.Find(a.B.Id);
       a.B = b;
       db.As.Add(a);
       db.SaveChanges();
    }
