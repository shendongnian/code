    if (!Page.IsPostBack)  // <--- here
    {
            Page.Validate();
            if (!Page.IsValid)
                    Response.Write("TextBox2 should be filled");
    }
