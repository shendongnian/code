    public class MyCustomList: List<MyCustomList>
    {
      //stuff you already have here, including your current constructors
      public MyCustomList(IEnumerable<MyCustomList> source)
      {
        //something here that (perhaps after using `this` to call
        //one of the existing constructors, loads all of the items
        //in source into it. There may be optimisations available
        //in particular cases, as a bonus.
      }
    }
