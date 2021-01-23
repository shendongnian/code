    @Html.DropDownListFor(m => **Model.SelectedValue**, Model.EmployeeSelectList, "-- Choose --", new {id = "employee_" +  item.ID })
    ...
    public class TheViewModel
    {
    public SelectList EmployeeSelectList {get;set;}
    public List<Row> Rows {get;set;}
    
    **public int SelectedValue{get;set;}**
    }
