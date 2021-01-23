    @model MvcApplication.Models.Employee
    @using (Html.BeginForm())
    {
                   
        @Html.TextBoxFor(m => m.EmpDepartment.Name)
        @Html.LabelForModel("SubOrdinates :")
        for (int i = 0; i < @Model.SubOrdinates.Count; i++)
        {
              @Html.TextBoxFor(m => (m.SubOrdinates[i].Name))
        }
    <input type="submit" name="name" value="Submit" />    }
