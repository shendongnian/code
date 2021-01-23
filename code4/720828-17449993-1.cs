    public class ListHasElements : ValidationAttribute
    {
       public override bool IsValid(List mylist)
       {
          if(mylist == null)
             return false;
       
          return mylist.Any();   
       }
    }
