    public ActionResult Save(Gamme gamme)
    {
        UserGammes.Add("currentUserID", gamme);
        // ... do stuff
    }
