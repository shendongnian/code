    class c1
    {
       DataTable t1;
       public void callC2()
       {
           C2 c2=new C2(t1);
       }   
    }
    
    class c2
    {
       DataTable t1;
       public C2(DataTable tbl)
       {
           t1=tbl;
       }
    }
