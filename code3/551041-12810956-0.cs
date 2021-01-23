    ...
    @model graduandModel
    @using Nop.Web.Models.Hire;
    @using Nop.Web.Framework;
    @using Telerik.Web.Mvc.UI;
    @using System.Linq;
    
    @using(Html.BeginForm("DetailForm", "ControllerName", FormMethod.Post, new {enctype="multipart/form-data"})
    {
    <table  >
    
     <tr>
        <td >
            @Html.LabelFor(model => model.ceremony_id)
        </td>
    ...
    
    //code omitted for brevity
    
    ...
    
    <input type="submit" id="btnsearchgraduand" name="btnsearch" class="searchbutton" value="@T("Search")" />
    
    })
