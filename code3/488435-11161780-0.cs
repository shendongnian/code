    public class Foo
    {
       public static CommonBaseClass GetGenericObject<T>() where T : CommonBaseClass
       {
          return (CommonBaseClass)Activator.CreateInstance<T>();
       }
       public void Test()
       {
          CommonBaseClass b = GetGenericObject<Type1Object>();
       }
    }
