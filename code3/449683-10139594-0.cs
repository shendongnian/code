    public class ClassB
     {
      public enum MyEnum
        {
         MyValue1,
         MyValue2
         }
       public static MyEnum Convert (ClassA.MyEnum originalValue)
        {
         return (MyEnum)Enum.Parse (typeof (MyEnum), originalValue.ToString());
        }
     } 
