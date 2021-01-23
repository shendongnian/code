    public ViewResult Index(Profile_Ga profile_ga)
    {
        // you need to decide if you want to use this
        // ViewBag.ID_Gamme = new SelectList(
        //     db.Profil_Gas, "ID_Gamme", profile_ga.ID_Gamme);
        // or this
        // return View(db.Profil_Gas.ToList());
        // but since it seems you are confuse to what you are doing
        // then I suggest you just do this
        // this will return a collection model to your view
        return View(db.Profil_Gas.ToList());
    }
