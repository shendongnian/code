    @model DriveAway.Web.Models.FooContainer
    @using(Html.BeginForm()) 
    {
        
        for (int i = 0; i < 5; i++)
        {
        	<p>@Html.TextBoxFor(m => m.Foos[i].Name)</p>
        	<p>@Html.TextBoxFor(m => m.Foos[i].Description)</p>
        }
    
        <button type="submit">Submit</button>
    
    }
    
    @ViewBag.Test
