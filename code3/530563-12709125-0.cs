         [Test]
         public void Should_get_object()
         {
            const string key = "1";
            const string value = "6";
            var mc = new MemcachedClient();
            var finish = mc.Store(Enyim.Caching.Memcached.StoreMode.Set, 
                                  key, value, TimeSpan.FromSeconds((double)60000));
             if(finish)
             {
                var obj=mc.Get(key);
                Assert.That(obj!=null,"obj is null.");
             }
        }
