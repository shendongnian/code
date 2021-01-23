    protected void Page_Load(object sender, EventArgs e)
    {
          if (!this.Page.IsPostBack)
          {
              if (Request.QueryString["File"] != null)
              {
                 if (Request.QueryString["File"].Contains("pdf"))
                     Response.ContentType = "application/pdf"; //varies depending on the file being streamed
                  Response.AddHeader("Content-Disposition", "attachment; filename=" + Request.QueryString["File"]);
                  Response.WriteFile(Server.MapPath(Request.QueryString["File"]));
               }
          }
    }
