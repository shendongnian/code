    public class MyDropDownList : DropDownList
    {
        public MyDropDownList()
        { 
              SelectedListItem item = new SelectListItem{Value="value", Text="text"};
              this.Items.Add(item);
              this.SelectedIndex = 0;
        }
    }
