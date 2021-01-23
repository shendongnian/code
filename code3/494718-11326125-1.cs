    public static void Foo<T>(this T objectC)
         where T: C
    {
         if(typeof(T)==typeof(B){ //or for runtime check:     if(objectC is B)
              //specific
         }
    }
