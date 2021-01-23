      public void Show(string msg)
      {
                Page page = HttpContext.Current.Handler as Page;
                if (page != null)
                {
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "msg", "alert('" + msg + "');", true);
                }
      }
