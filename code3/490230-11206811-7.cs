    @model TestIntegration.Models.ViewModelTwo
    @{
        ViewBag.Title = "About Us";
    }
    <h2>About</h2>
    <p>
         Put content here.
             @Html.Partial("InnerPartialView")
    </p>
