    class c1
    {
       DataTable t1;
       public void callC2()
       {
           C2 c2=new C2();
           c2.TargetMethod(t1);
       }   
    }
    
    class c2
    {
       public void TargetMethod(DataTable tbl)
       {       
          for(int i=0;i<tbl.Rows.Count;i++)
          // Do your works with tbl
    
       }
    }
