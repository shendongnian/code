    public class PEX
    {
     public List<PexWindow> Windows { get; set; }//list of windows you can foreach on
     public PEX()
     {
      Windows = new List<PexWindow>();//constructor to make sure the list can be worked with
     }
     private class PexWindow
     {
      public int Param { get; set; }
      public string Description { get; set; }
     }
    }
