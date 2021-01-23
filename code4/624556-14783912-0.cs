    @model Contoso.MvcApplication.Models.Assignment.ShareAssignmentViewModel
    
    @{
        ViewBag.Title = "ShareAssignment";
    }
    
    <h2>Share Assignment: @Model.Assignment.Name</h2>
    
    @for (int i = 0; i < Model.Classes.Length; i++)
    {
       var studentsArray = Model.Classes[i].Students.ToArray();
    <section>
        <h3>@Model.Classes[i].Name</h3>
    
        @for (int j = 0; j < studentsArray.Length; j++)
        {
            <input type="checkbox" 
                   name="@(string.Format("Classes[{0}].Students[{1}]", i, j))" 
                  value="@studentArray[j]" />
        }
    </section>
    }
