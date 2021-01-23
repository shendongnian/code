    public class YourModel 
    {    
    public List<UserList> OptionList { get; set; }
    public String YourValue{get;set;}
    }
    public class UserList
    {
       public String UserName{get;set;}
       public String UserId{get;set;}
    }
    @Html.DropDownListFor(model => model.YourValue, Model.OptionList, "")
