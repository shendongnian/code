    public ViewResult Index(Profile_Ga profile_ga, Poste poste)
    {
        return new ViewModel
                {
                     Postes = new SelectList(db.Postes, "ID_Poste", poste.ID_Poste),
                     Profile_Gas = new SelectList(db.Profil_Gas, "ID_Gamme", profile_ga.ID_Gamme);
                }
    }
