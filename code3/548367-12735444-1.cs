    public class MC1 : MasterClass
    {
    }
    
    public class MC2 : MasterClass
    {
    }
    
    IServerFuncs df = new DefaultFuncs<MC1>(new Table<MC1>());
    Table<MC2> table = df.getTable<MC2>();   // obviously not correct.
