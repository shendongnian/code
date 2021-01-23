        static class _FooDispatcher&lt;T&gt;
        {
            public static Action&lt;T&gt; Foo = setupFoo;
            static void doFooWithIGoodFoo&lt;TT&gt;(TT param) where TT : IGoodFoo
            {
                Console.WriteLine("Dispatching as IGoodFoo with {1} type {0}", typeof(TT).ToString(), typeof(TT).IsValueType ? "value" : "reference");
                param.Foo();
            }
            static void doFooWithIOkayFoo&lt;TT&gt;(TT param) where TT : IOkayFoo
            {
                Console.WriteLine("Dispatching as IOkayFoo with {1} type {0}", typeof(TT).ToString(), typeof(TT).IsValueType ? "value" : "reference");
                param.Foo();
            }
            static void doFooSomehow&lt;TT&gt;(TT param)
            {
                Console.WriteLine("Nothing exciting with {1} type {0}", typeof(TT).ToString(), typeof(TT).IsValueType ? "value" : "reference");
            }
            static void setupFoo(T param)
            {
                System.Reflection.MethodInfo mi;
                if (typeof(IGoodFoo).IsAssignableFrom(typeof(T)))
                    mi = typeof(_FooDispatcher&lt;T&gt;).GetMethod("doFooWithIGoodFoo", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
                else if (typeof(IOkayFoo).IsAssignableFrom(typeof(T)))
                    mi = typeof(_FooDispatcher&lt;T&gt;).GetMethod("doFooWithIOkayFoo", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
                else
                    mi = typeof(_FooDispatcher&lt;T&gt;).GetMethod("doFooSomehow", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
                Foo = (Action&lt;T&gt;)(@Delegate.CreateDelegate(typeof(Action&lt;T&gt;), mi.MakeGenericMethod(typeof(T))));
                Foo(param);
            }
        }
