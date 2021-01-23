    public ViewResult Index(Profile_Ga profile_ga, Poste poste)
    {
        return new ViewModel
                {
                     Postes = db.Postes.ToList(),
                     Profile_Gas = db.Profil_Gas.ToList();
                }
    }
