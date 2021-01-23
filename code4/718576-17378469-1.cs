    @{
         var counter = 1;
    }
    
    @( Html.Kendo().Grid<Types>()
       .Name("grid")
       .Columns(columns =>
       {           
            // Define a template column with row counter
           columns.Template(@<text>@counter++</text>);    
    
           // Define a columns from your data set and set a column setting
           columns.Bound(type => type.id);    
           
           columns.Bound(type=> type.name).Title("Name");    
           // add more columns here          
       })
    )
