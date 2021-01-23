    class Foo
    {
        private IRedisWrapper _redis;
        public Foo(IRedisWrapperFactory redisFactory)
        {
            _redis = redisFactory.Create();
        }
    }
