     BasicObject Finder(List<MyContainerClass> list, BasicObject o)
     {
          foreach (MyContainerClass i in list)
          {
               if (i.BasicObject == o) // same caveats on Equality
                   return i;
          }
          return null;
     }
