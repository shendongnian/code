    class MyClass {  public static int g=1;}
    
    using (TransactionScope tsTransScope = new TransactionScope())
    {
        Royi_s_gReturnerClass returner = new Royi_s_gReturnerClass();
        //Do stuff here
        MyClass.g=999;
        tsTransScope.Complete();
    }
