    public class MyEntity{
       public int Id {get;set;}
       public ICollection<OtherThing> Things {get;set;}
       [NotMapped]
       public OtherThing TheOneRealThing 
       {
           get
           {
               return Things.First();
           }
       }
    }
