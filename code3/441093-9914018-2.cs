    @{
      var days = new List<SelectListItem>();
      for( var i = 1; i <= 31; i++ ) {
        days.Add( new SelectListItem { Text = i.ToString(), Value = i.ToString(), Selected = Model.Day == i } );
      }
      var months = new List<SelectListItem> {
        new SelectListItem {Text = "Jan", Value = "1", Selected = Model.Month == 1},
        new SelectListItem {Text = "Feb", Value = "2", Selected = Model.Month == 2},
        new SelectListItem {Text = "Mar", Value = "3", Selected = Model.Month == 3},
        new SelectListItem {Text = "Apr", Value = "4", Selected = Model.Month == 4},
        new SelectListItem {Text = "May", Value = "5", Selected = Model.Month == 5},
        new SelectListItem {Text = "Jun", Value = "6", Selected = Model.Month == 6},
        new SelectListItem {Text = "Jul", Value = "7", Selected = Model.Month == 7},
        new SelectListItem {Text = "Aug", Value = "8", Selected = Model.Month == 8},
        new SelectListItem {Text = "Sep", Value = "9", Selected = Model.Month == 9},
        new SelectListItem {Text = "Oct", Value = "10", Selected = Model.Month == 10},
        new SelectListItem {Text = "Nov", Value = "11", Selected = Model.Month == 11},
        new SelectListItem {Text = "Dec", Value = "12", Selected = Model.Month == 12},
      };
      var years = new List<SelectListItem>();
      for( var i = 2009; i <= 2012; i++ ) {
        years.Add( new SelectListItem { Text = i.ToString(), Value = i.ToString(), Selected = Model.Year == i } );
      }
    }
    @using( Html.BeginForm() ) {
      @Html.DropDownListFor( x => x.Month, months )
      @Html.DropDownListFor( x => x.Day, days )
      @Html.DropDownListFor( x => x.Year, years )
      <input type="submit" />
    }
