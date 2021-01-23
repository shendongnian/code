     Following code will help you to find specific key,you have to specify * wildcard   
     character after string , will only fetch specific keys from Redis Server. 
 
     using (RedisClient redisClient = new RedisClient("localhost"))
     {
          string searchString = "ClassA*";
          var getSpecificKeys = redisClient.SearchKeys(searchString);
          foreach (var getKey in getSpecificKeys)
          {
               // operation
          }
      }
