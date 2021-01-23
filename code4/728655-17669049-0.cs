    public ActionResult SaveM(M m)
    {
        var mToEdit = db.find(m.Id);
        mToEdit.A = m.A;
        db.SaveChanges();
        //.......
    }
