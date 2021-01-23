    @{
      if (@Html.ViewContext.HttpContext.Request.QueryString["theme"] != null)
      {
        TProj.Objects.MyTheme.MyGlobalTheme = Html.ViewContext.HttpContext.Request.QueryString["theme"];
      }
      else
      {
        if (TProj.Objects.MyTheme.MyGlobalTheme == null)
        {
          TProj.Objects.MyTheme.MyGlobalTheme = "black";
        }
      }
    }
