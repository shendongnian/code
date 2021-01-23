    public class ListHasElements : ValidationAttribute
    {
       public override bool IsValid(List mylist)
       {
          if(mylist == null)
             return false;
       
          if(mylist.Count > 0)
             return true;
          return false;     
       }
    }
