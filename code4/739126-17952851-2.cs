    @Model.[MyIEnumberable].BuildGrid<Product>(grid=>{
    grid.ShowHeader = false;
    grid.CellSpacing = 0;
    grid.CellPadding = 0;
    grid.Decorator = "Com.MyCompany.DivDecorator";
    grid.columns(
            grid.column(HeaderText: "First Column", Decorator:"Com.MyCompany.FirstColumnDecorator"...),
            grid.column(HeaderText: "Second Column", Decorator:"Com.MyCompany.SecondColumnDecorator"..),
            grid.column(HeaderText: "ThirdColumn", Text:@item.ProductID),
            grid.column(HeaderText: "ThirdColumn", Text:@item.[A Property only exist in grid.Decorator, achieved using dynamic/DynamicObject])
    )
    })
