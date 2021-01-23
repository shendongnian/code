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
    public void Foo()
    {
        Ext.Atomic(() => {
            // foo logic
        }
    }
