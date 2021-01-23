      @{
          IDictionary<string, object> attributes = 
             new RouteValueDictionary(
                new { 
           style =  "color:black; float:left; padding:5px;", 
           @id = "ReportType"
         });
         if (Model.numCount > 500)
         { 
          // disable the item whose value = "RC-Report";
             attributes.Add("disabled", "disabled");
         }
         
      }
     @Html.DropDownList("ReportName", Model.ReportTypes, attributes);
