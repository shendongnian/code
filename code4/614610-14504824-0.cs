     public class testklass
        {
            public testklass()
            {
                new Subscription(a); // just to show you how i want to submit
                new Subscription(() => b("someparam"));
                new Subscription(()=>c(10, "someparam"));
            }
    
            private void a() { }
            private void b(string gg) { }
            private void c(int i, string g) { }
        }
