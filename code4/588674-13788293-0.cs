    class My<T>
    {
       public static bool can = CanWithDynamic();
       private static bool CanWithDynamic(). {
          dynamic runtimeT = default(T);
          return Helper.Can(runtimeT);
     }
