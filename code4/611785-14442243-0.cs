    public class AddProgramViewModel
    {
      //Your other properties here as well
      public string SelectedReminder { set;get;}
      public List<SelectListItem> ReminderList { set;get;}
      public AddProgramViewModel()
      {
         ReminderList=new List<SelectListItem>();
      }
    }
