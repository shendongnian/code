    @Model.[IEnumerable].Grid(grid=>{
          ..
          ...
          grid.columns(
             grid.Column<MyOwnColumnDecorator>("FirstColumn",null);
          )
    });
    
    @Model.[IEnumerable].Grid(grid=>{
          ..
          ...
          grid.columns(
             grid.Column<MyOwnColumnDecorator>("FirstColumn");
          )
    });
