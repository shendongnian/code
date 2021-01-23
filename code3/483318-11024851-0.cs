    public class Product
    {
      /* leave out other stuff */
      public virtual bool NeedsLargeBox
      {
        get
        {
          return false; // most products don't
          //(this property could also be abstract to force all derived
          //classes to decide upon how it operates)
        }
      }
    }
    public class Ring : Product
    {
      public int size;
      public virtual bool NeedsLargeBox
      {
        get
        {
          return size > 100;
        }
      }
    }
