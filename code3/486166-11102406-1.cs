    if (!Page.IsPostBack)
    {
        if (int.TryParse(Request.QueryString["id"], out bookId))
        {
            empName = Book.GetCopyOwner(bookId, Request.QueryString["owner"]);
            var display = (empName.Trim().Length > 0);
  
            panelReturnControls.Visible = display;
            panelCheckoutControls.Visible = !display;
        }
    }
