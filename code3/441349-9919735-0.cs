    public class TellAFriendViewModel
    {
     List<string> Emails { get; set; }
     public TellAFriendViewModel()
     {
      Emails = new List<string>(5);
     }
    }
    @using (Html.BeginForm()){
     @Html.AntiForgeryToken()
     @for(int count = 0 ; count < model.Emails.Count; count++)
     {
      @Html.TextBoxFor(vm => vm.Emails[count])
     }
    }
