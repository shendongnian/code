     public class AcessBaseDataMember
    {
       public static void Main()
       {
           DerivedClass obj = new DerivedClass();
           obj.Get_Base_DataMember();
           obj.Get_Derived_DataMember();
           Console.Read();
       }
   
       
    }
    public class BaseClass
    {
        protected int i = 13;
    }
