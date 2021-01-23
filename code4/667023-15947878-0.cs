    @{
        string url = "/Projects/_MonthRangesScriptsPartial";
        string onComplete = String.Format("updategraphArrayScript({0}, {1})", url, ViewBag.InputResourceID);
    }
    @using (Ajax.BeginForm(
      "_MonthRanges", 
      "Projects", 
      new { id = ViewBag.InputResourceID }, 
      new AjaxOptions { 
        HttpMethod = "POST", 
        UpdateTargetId = "MonthRanges", 
        InsertionMode = InsertionMode.Replace,
        OnComplete = "@onComplete"
      }))
