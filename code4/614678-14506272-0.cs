    public static class PeopleListFactory
    {
       public static IEnumerable<People> Content(int someindicator)
       {
          List<People> result = new List<People>();
          switch (someIndicator)
          {      
            case 0: // fill it in here with and from whatever you like.
            break;
          }
          return result;
       }
    }
