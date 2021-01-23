    @using (Ajax.BeginForm("Settings", "AffiliateProgram", Model.DataResponse, new AjaxOptions { UpdateTargetId = "result" }))
       {
          string commissionJson = JsonConvert.SerializeObject(Model.DataResponse.Entity.Commission);
          @Html.HiddenFor(data => data.DataResponse.Entity.Guid)
          @Html.Hidden("DataResponse_Entity_Commission", commissionJson)
          [Rest of my form]
       }
