    using (DataClassesDataContext db = new DataClassesDataContext())
    {
        Pagine pagina = new Pagine();
        db.Pagines.InsertOnSubmit(pagina);
        db.SubmitChanges();
    }
