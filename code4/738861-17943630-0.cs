    class MyClass
    {
          //if MyClass is sealed or static, then change protected to private.
          //if you need to access it from outside MyClass, change it to public.
          protected List<SrodkowaKolumna> list2 = new List<SrodkowaKolumna>();
   
          public void DoThis(string items)
          {
               if(//somethis)
               {
                     /// some more code
                     list2.Add(sk);
               }
          }
     }
