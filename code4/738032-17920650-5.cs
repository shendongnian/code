    public override void Execute(Guid contentDbId)
    {
           InsretListAvis addAvis = new InsretListAvis();
           List<AttributMail> listMail = Pmail.Affiche(); // static call
           foreach (AttributMail m in listMail)
           {
               info = addAvis.Insert(m.Projet, m.Phase, m);
           }
    }
