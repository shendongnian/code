    if (!IsPostBack) {
        linkButton1.CssClass = "";
        linkButton2.CssClass = "";
        linkButton3.CssClass = "";
        string linkButtonID = Request.RawUrl;
        if (-1 < linkButtonID.IndexOf("linkButton2")) {
          linkButton2.CssClass = "active";
        } else if (-1 < linkButtonID.IndexOf("linkButton3")) {
          linkButton3.CssClass = "active";
        } else {
          linkButton1.CssClass = "active"; // default
        }
    }
