    public MyEntities()
                : base("name=MyEntities")
            {
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;
            }
