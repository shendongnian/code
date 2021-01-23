     @model TestMVCProj.Models.TestPost
    @{
         ViewBag.Title ="TestPost";
    }
    @using (Html.BeginForm())
    {
         Html.TextBoxFor (x => x.name)
         <input type="submit" />
    }
    Your Name is @Model.name 
