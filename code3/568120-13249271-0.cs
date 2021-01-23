    e.g.
    @model UserManager.Models.vw_UserManager_Model_Add_Users 
    @{
        ViewBag.Title = "Create New User";
    }
    <h2>
        CreateUser</h2>
    @using (Html.BeginForm())
    {
    @Html.ValidationSummary(true)
    if(TempData["SuccessMsg"]!=null)
    {
    <div>TempData["SuccessMsg"].ToString()</div>
    }    
    }
           
