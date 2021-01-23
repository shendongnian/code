    @(Html.Kendo().Grid<Employee>()
         .Name("Grid")
         .Columns(columns =>
         {
             columns.Bound(p => p.Name).Width(50);
             columns.Bound(p => p.Department).Width(50).EditorTemplateName("DepartmentDropDownList");
             columns.Command(command => command.Edit()).Width(50);
         })
         .ToolBar(commands => commands.Create())
         .Editable(editable => editable.Mode(GridEditMode.InLine))
         .DataSource(dataSource => dataSource
             .Ajax() 
             .Model(model => model.Id(p => p.EmployeeId))
             .Read(read => read.Action("GetEmployees", "Home")) 
             .Update(update => update.Action("UpdateEmployees", "Home"))
             .Create(create => create.Action("CreateEmployee", "Home"))
         )
    )
