    //write
        bool IsNeedChangeDB=true;
        int WriteDBNumber=3
            public static PooledRedisClientManager pool = RedisDao.CreateManager(hostIp, hostIp);
            using (var redis = pool.GetClient())
                        {
                            if (redis is RedisClient && IsNeedChangeDB)
                            {
                                 if (redis.Db != this.WriteDBNumber)
                                    {
                                        ((RedisClient)redis).ChangeDb(this.WriteDBNumber);
                                    }
                                    else
                                    {
                                        Trace.WriteLine("it is a test" + redis.Host);
                                    }
                            }
                            redis.Set<string>("key","value");
                        }
    
    int ReadDBNumber=3;
    //read
    protected IRedisClient GetRedisClient()
            {
                var redis = pool.GetClient();
    
                if (redis is RedisClient && IsNeedChangeDB)
                {                
                    if (redis.Db != this.ReadDBNumber)
                        ((RedisClient)redis).ChangeDb(this.ReadDBNumber);
                }
    
                return  redis; 
            }
