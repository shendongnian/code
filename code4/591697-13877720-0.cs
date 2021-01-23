    public class A
    {
      public void A_Method()
      {
       try
       {
         string astr = B.B_Method();
       }
      catch(Exception ex)
      {
        //Handle it in A way
      }
    }
    public class C
    {
     public void C_Method()
      {
       try
       {
         string astr = B.B_Method();
       }
      catch(Exception ex)
      {
        //Handle it in C way
      }
    }
