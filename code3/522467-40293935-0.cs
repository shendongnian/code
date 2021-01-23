    using (var ctx = new DBPreparoEntities())
                {
                    var _client = from p in ctx.Client
                                     select new Client
                                     {
                                         data = new DateTime(2016,08,17),
                                         dateconf = null,
                                         scod_cli = p.Rua,
                                         valorini = 7214.62m,
                                     };
                    return client.ToList();
                }
