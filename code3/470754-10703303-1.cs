    public int Insert(List<Estrutura> lista)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            using (Entities ctx = new Entities (ConnectionType.Custom))
            {
                ctx.Connection.Open()
             
                id = this._dal.Insert(ctx, lista);
            }
        }
    }
    
    public int Insert(Entities ctx, List<Estrutura> lista)
    {
         ctx.AddToEstrutura(lista);
         ctx.SaveChanges();
    }
