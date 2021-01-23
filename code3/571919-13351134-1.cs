    public class Item
    {
      // other properties
     
      public int Status
      {
          get
          {
              if (ApprovedDate == null and DeclinedDate == null)
                  return 0;
              if (ApprovedDate != null and DeclinedDate == null)
                  return 1;
              if (DeclinedDate != null)
                  return 3;
              // etc
          }
      }
    }
