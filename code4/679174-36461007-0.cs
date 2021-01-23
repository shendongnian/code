    @model Pro.Web.Models.Model
    
    <div class="editor-field">
    @{ Html.EnableClientValidation(false); }
    @Html.TextBoxFor(model => model.Item.Date, new { @class = "picker" })
    @Html.ValidationMessageFor(model => model.Item.Date)
    @{ Html.EnableClientValidation(true); }
                   
        
