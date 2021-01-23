    public class ConfirmUserViewModel
    {      
      public List<ReportedUserViewModel> ReportedUsers{ get; set; }      
      //Other Properties also here
    
      public ConfirmUserViewModel()
      {
        ReportedUsers=new List<ReportedUserViewModel>();       
      }    
    }
