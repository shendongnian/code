    public class MyDropDownList : IEnumerable<SelectListItem> 
    {
        public MyDropDownList()
        { 
              SelectedListItem item = new SelectListItem{Value="value", Text="text"};
              this.Add(item);
        }
    }
