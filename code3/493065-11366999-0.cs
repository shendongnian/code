    public class Child
    {
      public string ImageURL { set;get;}
      //other properties & construct etc 
    }
    public class Master
    {
      IEnumerable<Child> Children { set;get;}
    }
