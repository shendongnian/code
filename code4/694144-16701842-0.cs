    [HttpPost]
    public ActionResult Save(FlowViewModel model)
    {
        if (ModelState.IsValid)
        {
            Gamme G = new Gamme();
            G.ID_Gamme = model.SelectedProfile_Ga;
            G.ID_Poste = model.SelectedPoste;
            G.Next_Posts = model.PosteSuivantSelected;
            G.Nbr_Passage = int.Parse(model.Nbr_Passage);
            G.Position = int.Parse(model.Position);
            model.ListG = db.Gammes.ToList();
            model.ListG.Add(G);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
