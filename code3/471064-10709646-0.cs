    @{
        var ratings = new List<SelectListItem>();
        for( var i = 0; i <= 10; i++ ) {
            days.Add( new SelectListItem { Text = i.ToString(), Value = i.ToString(), Selected = Model.RATE == i } );
        }
    }
    @Html.DropDownListFor( x => x.RATE, ratings )
    
