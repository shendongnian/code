    public class CustomerViewModel
    {
      public IEnumerable<Option> OptionList { set;get;}
      public CustomerViewModel()
      {
         OptionList=new List<Option>();
      }
    }
