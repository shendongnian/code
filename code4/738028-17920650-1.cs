    class OPPSVotesStatistiques : SPJobDefinition
    {
        public override void Execute(Guid contentDbId)
        {
           Pmail p = new Pmail();
           InsretListAvis addAvis = new InsretListAvis();
           List<AttributMail> listMail = p.affiche();
           foreach (AttributMail m in listMail)
           {
               info = addAvis.Insert(m.Projet, m.Phase, m);
           }
        }
    }
