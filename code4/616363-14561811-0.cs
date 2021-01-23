    using System;
    using System.Text;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using ServiceStack.OrmLite;
    using ServiceStack.Common;
    using ServiceStack.Common.Utils;
    using ServiceStack.DesignPatterns.Model;
    using ServiceStack.ServiceInterface;
    using ServiceStack.CacheAccess;
    using ServiceStack.ServiceHost;
    using ServiceStack.Redis;
    
    namespace Redis.Extensions
    {
        public static class RedisExtensions
        {
            internal static T GetFromCache<T>(this IRedisClient redisClient, string cacheKey,
                Func<T> factoryFn,
                TimeSpan expiresIn)
            {
                var res = redisClient.Get<T>(cacheKey);
                if (res != null)
                {
                    redisClient.Set<T>(cacheKey, res, expiresIn);
                    return res;
                }
                else
                {
                    res = factoryFn();
                    if (res != null) redisClient.Set<T>(cacheKey, res, expiresIn);
                    return res;
                }
            }
    
        }
    }
