    public class IdWithFlag
    {
         public int Id { get; set; }
         public bool Selected { get; set; }
    }
    Dictionary<int, IdWithFlag> allIDs = ... // populate somehow, perhaps a custom cast operator would help
   
