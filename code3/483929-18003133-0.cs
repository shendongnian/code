          public override void Configure(Funq.Container container){
    
          var redisCon = ConfigurationManager.AppSettings["redisUrl"].ToString();
          container.Register<IRedisClientsManager>(new PooledRedisClientManager(20, 60, redisCon));
          container.Register<ICacheClient>(c =>(ICacheClient)c.Resolve<IRedisClientsManager>().GetCacheClient());
        }
