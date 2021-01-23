    @model DynamicControlsCreation.ViewModels.DefaultControlsViewModel 
    <p>
        @using (Html.BeginForm())
        {
            for (int i = 0; i < Model.Controls.Count; i++)
            {         
            <div>
                @Html.HiddenFor(x => x.Controls[i].Type)
                @Html.HiddenFor(x => x.Controls[i].Name)
                @Html.EditorFor(x => x.Controls[i])
            </div>       
            } 
    
            <input type="submit" value="Submit" /> 
        }
    </p>
