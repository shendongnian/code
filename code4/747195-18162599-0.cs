    public IQueryable<T> GetData<T>( string identifier )
    {
         switch( identifier )
         {
             case "Vente":
             {
                 return ContexteDAO.ContexteDonnees.Vente
                                                   .Include("Client")
                                                   .Include("Paiement")
                                                   .Include("Employe")
                                                   .OrderBy(v => v.venteID);
                 // do more stuff
                 break;
             }
             // add more cases
             default:
             {
                 return null;
             }
         }
    }
