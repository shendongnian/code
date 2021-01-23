            var instance = new Foo();
            var type = instance.GetType();
            var meth = type.GetMethod("PrivateMeth", BindingFlags.NonPublic | BindingFlags.Instance);
            
            if(meth != null)
                meth.Invoke(instance, new object[0] { });
