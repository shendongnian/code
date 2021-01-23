    public class StatusList
    {
       public int StatusID {get;set;}
       public byte Active {get;set;}
       [NotMapped]
       public bool ActiveBool
       {
           get { return Active > 0; }
           set { Active = value ? 1 : 0; }
       }
    }
