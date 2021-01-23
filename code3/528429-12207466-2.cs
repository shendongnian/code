    @using (Html.BeginForm())
    {
        <p>
            @{ModelState state = ViewData.ModelState["ClientName"];            
            }
            @Html.LabelFor(m => m.ClientName, "Your name: ")
            @if (state != null && state.Errors.Count > 0)
            {
                @Html.TextBoxFor(m => m.ClientName, new { @class = "other-input-validation-error" })
            }
            else
            {
                @Html.EditorFor(m => m.ClientName)
            }
            @Html.ValidationMessageFor(m => m.ClientName)
        </p>        
    }
