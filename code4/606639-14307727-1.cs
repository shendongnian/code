    public static class Ext 
    {
        public static void Atomic(Action action) 
        {
            using(var scope = new TransactionScope()) 
            {
                action();
                scope.Commit();
            }
        }
    }
    .....
    using static Ext; // as of VS2015
    public void Foo()
    {
        Atomic(() => {
            // foo logic
        }
    }
