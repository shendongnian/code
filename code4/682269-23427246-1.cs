    protected void Submit(object sender, EventArgs e)
    {
       string confirmValue = Request.Form["confirm_value"];
       if (confirmValue == "Yes")
       {
          Response.Redirect("~/AddData.aspx");
       }
       else
       {
          Response.Redirect("~/ViewData.aspx");
       }
    }
