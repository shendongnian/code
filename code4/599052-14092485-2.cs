    public class Note
    {
      /* ... other properties ... */
      public bool IsHistoric { get { return this.TypeId != 1; } }
    }
