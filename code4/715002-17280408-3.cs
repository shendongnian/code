    @model OilNGasWeb.Models.Home.IndexViewModel
    @{
      ViewBag.Title = "Index";
    }
    <h2>County's for </h2> 
    <p>
      // send a ClientID with this action link
      @Html.ActionLink("Create New", "Create", new { clientid = Model.ClientID } ) 
    </p>
    //... etc
