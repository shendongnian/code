    public static void SaveFromList(IList<VM_CategoryLabelExtra> listTemplate)
        {
            int idCat = listTemplate.Select(x => x.IdCat).FirstOrDefault();
            var test = (int)listTemplate.Where(z => z.Id == 8).Select(z => z.Order).FirstOrDefault();
        using (var context = new my_Entities())
        {
            var requete = from x in context.arc_CatLabel
                          where x.ID_Categorie == idCat
                          orderby x.Sequence_Cat
                          let list = from q in listTemplate
                                     q
                          select new VM_CategoryLabel
                          {
                              Id = x.ID_LabelPerso,                              
                              Order = list.Where(z => z.Id == x.ID_LabelPerso).Select(z => z.Order).First(),                             
                              Label = x.arc_Label.Label,
                              Unit = x.arc_Label.Unit
                          };
            context.SaveChanges();
        }
    }
